#include <Arduino.h>
#include <PubSubClient.h>
#include <WiFiClientSecure.h>
#include <ArduinoJson.h>

const int numControls = 8;  // Số lượng công tắc và LEDs
const int buttonPins[numControls] = {32, 33, 25, 26, 27, 14, 12, 13}; // GPIOs cho các công tắc, giả sử đây là các pin bên phải của module
const int ledPins[numControls] = {23, 22, 21, 19, 18, 5, 16, 17}; // GPIOs cho các LED, giả sử đây là các pin bên trái của module

unsigned long lastMsgTime = 0; // Biến lưu thời gian lần gửi cuối cùng
const long interval = 2000;    // Khoảng thời gian gửi trạng thái LED, đơn vị là milliseconds (2000 ms = 2 giây)

//const int wifiIsConnected = D8;
// const char* ssid = "FPT DU";
// const char* password = "du0977654650";
const char* ssid = "Avid";
const char* password = "++112233";
// const char* ssid = "Sinh Hien";
// const char* password = "++112233";

const char* mqtt_server = "50b1dfc82a5a4ea2a4e6462bbf4f2fd5.s1.eu.hivemq.cloud";
const int mqtt_port = 8883;
const char* mqtt_username = "farm2";        // User
const char* mqtt_password = "Admin@12345";  // Password



bool ledStates[numControls] = {0};  // Trạng thái hiện tại của LEDs
bool lastButtonStates[numControls] = {0}; // Trạng thái cuối của công tắc

WiFiClientSecure espClient;
PubSubClient client(espClient);


void setup_wifi() {
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);
  unsigned long startAttemptTime = millis();
  while (WiFi.status() != WL_CONNECTED && millis() - startAttemptTime < 5000) {
    // Non-blocking delay to keep button responsiveness
    handleButtonPresses();
    delay(100);
    Serial.print(".");
  }
  if (WiFi.status() == WL_CONNECTED) {
    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());
  } else {
    Serial.println("Failed to connect to WiFi");
  }
}


//------------Connect to MQTT Broker-----------------------------
void reconnect() {
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    String clientID = "ESPClient-";
    clientID += String(random(0xffff), HEX);
    if (client.connect(clientID.c_str(), mqtt_username, mqtt_password)) {
      Serial.println("connected");
      client.subscribe("esp8266/ledControl"); // Đăng ký vào chủ đề để nhận tin nhắn điều khiển đèn LED
      client.subscribe("Control/Schedule/KV2"); /// đăng kí nhận lập lịch bắn message để điều kiển
      //digitalWrite(wifiIsConnected, LOW);
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      //digitalWrite(wifiIsConnected, HIGH);
      Serial.println(" try again in 5 seconds");
      delay(5000);
    }
  }
}



void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  
  StaticJsonDocument<400> doc;            // Tạo một đối tượng JSON Document
  deserializeJson(doc, payload, length);  // Phân tích JSON từ payload

  // Xử lý message kiểu {"Id": "xxx", "Status": true, "Order": 0}
  if (doc.containsKey("Order")) {
    int deviceOrder = doc["Order"];        // Lấy giá trị 'Order'
    bool newState = doc["Status"];         // Lấy giá trị 'Status'
  
    Serial.print("Order received for board ");
    Serial.print(deviceOrder);
    Serial.print(" to turn ");
    Serial.println(newState ? "ON" : "OFF");

    // Kiểm tra deviceOrder có hợp lệ và cập nhật trạng thái tương ứng
    if (deviceOrder >= 0 && deviceOrder < sizeof(ledPins) / sizeof(ledPins[0])) {
      digitalWrite(ledPins[deviceOrder], newState ? HIGH : LOW);
    }
  }

  // Xử lý message kiểu {"Type":1,"Area":"KV2","AreaSensor":"KV2","Value":32.29999924,"Status":"Value is within the range","Devices":[{"DeviceOrder":0,"StatusDevice":"On"}]}
  if (doc.containsKey("Devices")) {
    JsonArray devices = doc["Devices"].as<JsonArray>();
    for (JsonObject device : devices) {
      int deviceOrder = device["DeviceOrder"];
      const char* statusDevice = device["StatusDevice"];

      Serial.print("Device ");
      Serial.print(deviceOrder);
      Serial.print(" to turn ");
      Serial.println(strcmp(statusDevice, "On") == 0 ? "ON" : "OFF");

      // Kiểm tra deviceOrder có hợp lệ và cập nhật trạng thái tương ứng
      if (deviceOrder >= 0 && deviceOrder < sizeof(ledPins) / sizeof(ledPins[0])) {
        digitalWrite(ledPins[deviceOrder], strcmp(statusDevice, "On") == 0 ? HIGH : LOW);
      }
    }
  }
}

void setup() {


  Serial.begin(9600);
  while (!Serial) delay(1);
  setup_wifi();
  espClient.setInsecure();
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);


  // Cấu hình các pins cho công tắc là INPUT_PULLUP và LEDs là OUTPUT
  for (int i = 0; i < numControls; i++) {
    pinMode(buttonPins[i], INPUT_PULLUP);
    pinMode(ledPins[i], OUTPUT);
    digitalWrite(ledPins[i], LOW); // Tắt tất cả LEDs ban đầu
  }
}

// Hàm gửi trạng thái LED qua MQTT
void sendLedStatus() 
{
  StaticJsonDocument<200> statusDevice;  // Kích thước cần thay đổi tùy vào nhu cầu
  JsonArray status = statusDevice.createNestedArray("Status");

  // Điền trạng thái của mỗi LED vào mảng JSON
  for (int i = 0; i < sizeof(ledPins) / sizeof(ledPins[0]); i++) {
    status.add(digitalRead(ledPins[i]));
  }
  statusDevice["Name"] = "KV2";
  // Serialize JSON để gửi
  char jsonBuffer[512];
  serializeJson(statusDevice, jsonBuffer);

  // Gửi thông điệp JSON qua MQTT
  client.publish("esp8266/ledStatus", jsonBuffer);

}
void handleButtonPresses() {
  for (int i = 0; i < numControls; i++) {
    bool currentButtonState = !digitalRead(buttonPins[i]);
    if (currentButtonState != lastButtonStates[i]) {
      delay(50); // Debouncing
      lastButtonStates[i] = currentButtonState;

      if (currentButtonState == HIGH) {
        ledStates[i] = !ledStates[i];
        digitalWrite(ledPins[i], ledStates[i]);
      }
    }
  }
}

void loop() {
  handleButtonPresses();

  if (WiFi.status() != WL_CONNECTED) {
    static unsigned long lastReconnectAttempt = 0;
    unsigned long currentMillis = millis();
    if (currentMillis - lastReconnectAttempt > 10000) { // Thử kết nối lại sau mỗi 10 giây
      lastReconnectAttempt = currentMillis;
      Serial.println("WiFi disconnected, attempting to reconnect...");
      setup_wifi();
    }
  } else {
    if (!client.connected()) {
      reconnect();
    }
    client.loop();

    if (millis() - lastMsgTime > interval) {
      lastMsgTime = millis();
      sendLedStatus();
    }
  }
}







#include <ESP8266WiFi.h>
#include <WiFiClientSecure.h>
#include <PubSubClient.h>
#include <DHT.h>
#include <BH1750.h>
#include <ArduinoJson.h>
#include <Wire.h>

const char* ssid = "Avid";
const char* password = "++112233";
// const char* ssid = "Sinh Hien";
// const char* password = "++112233";
const char* mqtt_server = "50b1dfc82a5a4ea2a4e6462bbf4f2fd5.s1.eu.hivemq.cloud";
const int mqtt_port = 8883;
const char* mqtt_username = "farm5";
const char* mqtt_password = "Admin@12345";

const int DHTPIN = 5;  // Use D2 on ESP8266
#define DHTTYPE DHT11

DHT dht(DHTPIN, DHTTYPE);
BH1750 lightMeter;
WiFiClientSecure httpsClient;
PubSubClient mqttClient(httpsClient);

unsigned long previousMillis = 0;
const long interval = 3000;  // Interval for MQTT sending

void setup() {
  Serial.begin(115200);
  // Adjusted pin numbers for I2C on ESP8266 (e.g., D1 and D2)
  Wire.begin(D3, D2);  // SDA, SCL //
  dht.begin();
  lightMeter.begin();
  WiFi.mode(WIFI_STA);
  connectToWiFi();
  setupMQTT();
}

void loop() {
  if (!mqttClient.connected()) {
    Serial.println("MQTT not connected, attempting reconnect...");
    reconnectMQTT();
  }
  mqttClient.loop();

  unsigned long currentMillis = millis();
  if (currentMillis - previousMillis >= interval) {
    previousMillis = currentMillis;
    sendDataToMQTT();
  }
  delay(2000);  // Using delay()
}

void connectToWiFi() {
  Serial.print("Connecting to WiFi");
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nWiFi connected");
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
}

void setupMQTT() {
  httpsClient.setInsecure();  // Use with caution in production
  mqttClient.setServer(mqtt_server, mqtt_port);
  mqttClient.setKeepAlive(60);
  mqttClient.setCallback(callback);
  reconnectMQTT();
}

void reconnectMQTT() {
  while (!mqttClient.connected()) {
    Serial.println("Attempting to connect to MQTT Broker...");
    if (mqttClient.connect("ESP8266Client", mqtt_username, mqtt_password)) {
      Serial.println("Connected to MQTT Broker");
      mqttClient.subscribe("schedule/KV2");
    } else {
      Serial.print("MQTT connection failed, rc=");
      Serial.println(mqttClient.state());
      delay(5000);  // Increase delay to reduce the number of reconnect attempts
    }
  }
}
// void callback(char* topic, byte* payload, unsigned int length) {
//   Serial.print("Message arrived [");
//   Serial.print(topic);
//   Serial.print("] ");

//   // Convert the payload to a string
//   String message;
//   for (int i = 0; i < length; i++) {
//     message += (char)payload[i];
//   }

//   Serial.println(message);

//   // Check if message length exceeds buffer capacity
//   if (length > 512) { // Assumes a typical max JSON size that you expect
//     Serial.println("Warning: Message size may exceed buffer capacity.");
//   }

//   // Parse the JSON message
//   StaticJsonDocument<1024> doc;  // Increased buffer size to handle more complex messages
//   DeserializationError error = deserializeJson(doc, message);

//   if (error) {
//     Serial.print("Failed to parse incoming message: ");
//     Serial.println(error.c_str());
//     return;
//   }

//   int type = doc["Type"];
//   float valueStart = doc["ValueStart"];
//   float valueEnd = doc["ValueEnd"];
//   String area = doc["Area"];
//   String areaSensor = doc["AreaSensor"];
//   JsonArray devices = doc["Device"].as<JsonArray>(); // "Device" is an array

//   Serial.print("Processing Type: ");
//   Serial.println(type);
//   Serial.print("Sensor Value Range: ");
//   Serial.print(valueStart);
//   Serial.print(" to ");
//   Serial.println(valueEnd);

//   float sensorValue = 0.0;

//   // Read sensor value based on the type
//   switch (type) {
//     case 1:  // Temperature
//       sensorValue = dht.readTemperature();
//       break;
//     case 2:  // Humidity
//       sensorValue = dht.readHumidity();
//       break;
//     case 3:  // Light level
//       sensorValue = lightMeter.readLightLevel();
//       break;
//     default:
//       Serial.println("Unknown sensor type");
//       return;
//   }

//   Serial.print("Sensor Value: ");
//   Serial.println(sensorValue);

//   // Check if the sensor value is within the specified range
//   bool isInRange = (sensorValue >= valueStart && sensorValue <= valueEnd);
//   Serial.print("Is value in range? ");
//   Serial.println(isInRange ? "Yes" : "No");

//   if (isInRange) {
//     // Create a JSON document to store responses for all devices
//     StaticJsonDocument<1024> responseDoc;
//     responseDoc["Type"] = type;
//     responseDoc["Area"] = area;
//     responseDoc["AreaSensor"] = areaSensor;
//     responseDoc["Value"] = sensorValue;
//     responseDoc["Status"] = "Value is within the range";

//     JsonArray responseDevices = responseDoc.createNestedArray("Devices");

//     for (JsonObject device : devices) {
//       int deviceOrder = device["Order"];
//       bool statusDevice = device["Status"];

//       JsonObject respDevice = responseDevices.createNestedObject();
//       respDevice["DeviceOrder"] = deviceOrder;
//       respDevice["StatusDevice"] = statusDevice ? "On" : "Off";
//     }

//     String responsePayload;
//     serializeJson(responseDoc, responsePayload);
//     mqttClient.publish(String("Control/Schedule/" + areaSensor).c_str(), responsePayload.c_str());

//     Serial.println("Response sent to MQTT broker");
//   } else {
//     Serial.println("Value out of range - no message sent");
//   }
// }
void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived on topic [");
  Serial.print(topic);
  Serial.print("] with length ");
  Serial.println(length);

  // Convert the payload to a string
  String message;
  for (int i = 0; i < length; i++) {
    message += (char)payload[i];
  }

  Serial.println("Received Message: ");
  Serial.println(message);

  // Ensure the message length does not exceed expected buffer size
  if (length > 1024) {  // Check if the actual length exceeds a larger buffer size
    Serial.println("Warning: Message size may exceed buffer capacity.");
    return;  // Optionally, return to avoid processing an oversized message
  }

  // Parse the JSON message
  StaticJsonDocument<2048> doc;  // Increased buffer size for more complex JSON structures
  DeserializationError error = deserializeJson(doc, message);

  if (error) {
    Serial.print("Failed to parse incoming message: ");
    Serial.println(error.c_str());
    return;
  }

  int type = doc["T"];
  float valueStart = doc["VS"];
  float valueEnd = doc["VE"];
  String area = doc["A"];
  JsonArray devices = doc["D"].as<JsonArray>();

  Serial.print("Processing Type: ");
  Serial.println(type);
  Serial.print("Sensor Value Range: ");
  Serial.print(valueStart);
  Serial.print(" to ");
  Serial.println(valueEnd);

  float sensorValue = readSensorValueByType(type);

  // Check if the sensor value is within the specified range
  bool isInRange = (sensorValue >= valueStart && sensorValue <= valueEnd);
  Serial.print("Is value in range? ");
  Serial.println(isInRange ? "Yes" : "No");

  if (isInRange) {
    respondToDevices(devices, type, area, sensorValue);
  } else {
    Serial.println("Value out of range - no message sent.");
  }
}

// Function to read the sensor value based on the provided type
float readSensorValueByType(int type) {
  switch (type) {
    case 1:  // Temperature
      return dht.readTemperature();
    case 2:  // Humidity
      return dht.readHumidity();
    case 3:  // Light level
      return lightMeter.readLightLevel();
    default:
      Serial.println("Unknown sensor type");
      return NAN;
  }
}
void ensureConnected() {
    if (!mqttClient.connected()) {
        Serial.println("Đang kết nối lại MQTT...");
        if (mqttClient.connect("clientId")) {
            Serial.println("Đã kết nối");
            // Đăng ký lại topic nếu cần
            mqttClient.subscribe("schedule/KV2");
        } else {
            Serial.print("Thất bại, thử lại sau 5 giây. Mã lỗi: ");
            Serial.println(mqttClient.state());
            delay(5000);
        }
    }
}
// Function to create a response JSON and send it over MQTT
void respondToDevices(JsonArray& devices, int type, String area, float sensorValue) {
  ensureConnected();
  StaticJsonDocument<2048> responseDoc;
  JsonArray responseDevices = responseDoc.createNestedArray("Devices");
  for (JsonObject device : devices) {
    JsonObject respDevice = responseDevices.createNestedObject();
    respDevice["DeviceOrder"] = device["Order"].as<int>();
    respDevice["StatusDevice"] = device["Status"].as<bool>() ? "On" : "Off";
    Serial.print("DeviceOrder: ");
    Serial.println(device["Order"].as<int>());
    Serial.print("StatusDevice: ");
    Serial.println(device["Status"].as<bool>() ? "On" : "Off");
  }

  String responsePayload;
  serializeJson(responseDoc, responsePayload);
  Serial.print("Response Payload Size: ");
  Serial.println(responsePayload.length()); // Xuất kích thước của payload
  
  if (!mqttClient.publish(String("Control/Schedule/" + area).c_str(), responsePayload.c_str())) {
    Serial.println("Lỗi: Không thể gửi thông điệp.");
  } else {
    Serial.println("Thông điệp đã được gửi đến MQTT broker.");
  }
}




void sendDataToMQTT() {
  float humidity = dht.readHumidity();
  float temperature = dht.readTemperature();
  float lux = lightMeter.readLightLevel();

  if (!isnan(humidity) && !isnan(temperature) && !isnan(lux)) {
    StaticJsonDocument<200> doc;
    doc["temperature"] = temperature;
    doc["humidity"] = humidity;
    doc["brightness"] = lux;
    doc["sensorLocation"] = "KV2";
    String payload;
    serializeJson(doc, payload);

    if (mqttClient.publish("KV2", payload.c_str())) {
      Serial.println("Data sent to MQTT broker");
    } else {
      Serial.println("Error sending data to MQTT broker");
    }
  } else {
    Serial.println("Failed to read from sensors!");
  }
}

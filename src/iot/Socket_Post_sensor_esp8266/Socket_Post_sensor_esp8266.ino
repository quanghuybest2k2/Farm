#include <ESP8266WiFi.h>
#include <WiFiClientSecure.h>
#include <DHT.h>
#include <BH1750.h>
#include <ArduinoJson.h>
#include <ESP8266HTTPClient.h>

const char* ssid = "Avid";
const char* password = "++112233";
const char* serverAddress = "https://www.sensor-io.somee.com/api/environments";

const int DHTPIN = 5; // GPIO5 (D1 on ESP8266)
#define DHTTYPE DHT11 // Define sensor type

DHT dht(DHTPIN, DHTTYPE);
BH1750 lightMeter;
WiFiClientSecure httpsClient;

unsigned long previousHTTPMillis = 0;
const long httpInterval = 5000; // Interval for HTTP requests in milliseconds

void setup() {
  Serial.begin(115200);
  WiFi.mode(WIFI_STA);
  connectToWiFi();
  Wire.begin(D3, D2); // SDA, SCL
  dht.begin();
  lightMeter.begin();
}

void loop() {
  unsigned long currentMillis = millis();
  if (currentMillis - previousHTTPMillis >= httpInterval) {
    previousHTTPMillis = currentMillis;
    sendDataToServer();
  }
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


void sendDataToServer() {
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;
    httpsClient.setInsecure();
    http.begin(httpsClient, serverAddress);
    Serial.println("Sending HTTP request to: " + String(serverAddress));

    int humidity = dht.readHumidity();
    int tempValue = dht.readTemperature();
    uint16_t lux = lightMeter.readLightLevel();

    if (!isnan(humidity) && !isnan(tempValue)) {
      StaticJsonDocument<200> doc;
      doc["temperature"] = tempValue;
      doc["humidity"] = humidity;
      doc["brightness"] = lux;
      doc["sensorLocation"] = "KV2";
      String payload;
      serializeJson(doc, payload);
      Serial.print("Sending to topic sensor/data: ");
      Serial.println(payload);
      http.addHeader("Content-Type", "application/json");
      int httpCode = http.POST(payload);
      Serial.println(httpCode);
      if (httpCode > 0) {
        String response = http.getString();
        Serial.println("HTTP Response code: " + String(httpCode));
        Serial.println("Response from server: " + response);
      } else {
        Serial.print("Error sending data: ");
        Serial.println(http.errorToString(httpCode));
      }

      http.end();
    } else {
      Serial.println("Failed to read from DHT sensor!");
    }
  } else {
    Serial.println("Not connected to WiFi");
  }
}




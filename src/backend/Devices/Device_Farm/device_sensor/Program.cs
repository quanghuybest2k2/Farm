using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using device_sensor.Constant;
using System.Security.Cryptography.X509Certificates;
using device_sensor.Model.Request;
using device_sensor.Devices;
using System;
using device_sensor.Model;
using device_sensor.Model.Response;
using System.Net.NetworkInformation;
using System.Xml.Linq;

#region Class Info


public class Location
{
    public string Name { get; set; }
    public string Region { get; set; }
    public string Country { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Tz_id { get; set; }
    public long Localtime_epoch { get; set; }
    public DateTime Localtime { get; set; }
}

public class Condition
{
    public string Text { get; set; }
    public string Icon { get; set; }
    public int Code { get; set; }
}

public class Current
{
    public long Last_updated_epoch { get; set; }
    public DateTime Last_updated { get; set; }
    public double Temp_c { get; set; }
    public double Temp_f { get; set; }
    public int Is_day { get; set; }
    public Condition Condition { get; set; }
    public double Wind_mph { get; set; }
    public double Wind_kph { get; set; }
    public int Wind_degree { get; set; }
    public string Wind_dir { get; set; }
    public int Pressure_mb { get; set; }
    public double Pressure_in { get; set; }
    public int Precip_mm { get; set; }
    public int Precip_in { get; set; }
    public int Humidity { get; set; }
    public int Cloud { get; set; }
    public double Feelslike_c { get; set; }
    public double Feelslike_f { get; set; }
    public int Vis_km { get; set; }
    public int Vis_miles { get; set; }
    public double Gust_mph { get; set; }
    public double Gust_kph { get; set; }
}


public class WeatherData
{

    public Location Location { get; set; }
    public Current Current { get; set; }
}

#endregion

#region getWeatherInfo
public static class Sending
{
    private readonly static string ApiKey = "7e714d1037ae4cf7a20124546242303";
    private readonly static string Location = "11.955258, 108.448173";
    private readonly static string DefaultLanguage = "vi";
    private readonly static int Days = 7;
    private readonly static string ApiUrl = $"https://api.weatherapi.com/v1/forecast.json?q={Location}&days={Days}&lang={DefaultLanguage}&key={ApiKey}&alerts=yes&aqi=yes";
    public async static Task<WeatherData> GetWeatherInfo()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {

                // Make a GET request to the API
                HttpResponseMessage response = await client.GetAsync(ApiUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JObject jsonObject = JObject.Parse(responseBody);

                    WeatherData weatherData = jsonObject.ToObject<WeatherData>();

                    // Return the WeatherData object
                    return weatherData;
                }
                else
                {
                    Console.WriteLine($"Failed to call API. Status code: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw new();
            }
        }
    }
}
#endregion
public class DeviceInfo
{
    public DeviceInfo()
    {
        Id = "sensor-0";
        DeviceName = "Sensor 1";
        Type = "Sensor";
        Status = true;
    }

    public string Id { get; set; } = "sensor-0";
    public string DeviceName { get; set; } = "Sensor 1";
    public string Type { get; set; } = "Sensor";
    public bool Status { get; set; } = true;
}
public class Program
{
    public enum MessageType
    {
        DeviceInfo = 1,
        WeatherData = 2
    }
    private static Func<bool, string> Convert = e => e ? "bật" : "tắt";
   
    private static string Print(device_sensor.Model.Device device)
    {

        return $"Device {device.Id} {device.Type} {device.Name} {Convert(device.Status)} ";
    }

    public static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        const string deviceId = "03de1476-0eda-4fa1-b1db-5d4fe8e4321c";
        using (ClientWebSocket client = new ClientWebSocket())
        {
            try
            {
                await client.ConnectAsync(new Uri(Common.ServerUrl), CancellationToken.None);
                Console.WriteLine("WebSocket client connected.");
                var deviceInfo = WebSocketMessage<DeviceInfo>.SocketRequest(new DeviceInfo(), deviceId, MessageType.DeviceInfo); // constructor device Info 

                var sendBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(deviceInfo)));

                await client.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);

                var receiveBuffer = new byte[1024 * 4];

                while (client.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result;
                    try
                    {
                        result = await client.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);
                        if (result.Count == 0)
                        {
                            break;
                        }
                    }
                    catch (WebSocketException wse)
                    {
                        Console.WriteLine("WebSocketException: " + wse.Message);
                        break;
                    }

                    // Handle incoming messages
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        string jsonString = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);
                        var message = JsonConvert.DeserializeObject<WebSocketMessage<DeviceDTO>>(jsonString);
                        var messageType = message.MessageType;
                        var data=message.Data;
                        var Device = message.Data;
                        Console.WriteLine("Message received from server: " + message.MessageType);

                        // Implement message handling logic
                        // ...
                        switch (messageType)
                        {
                            case MessageType.WeatherData:
                                var weatherInfo = WebSocketMessage<WeatherData>.SocketRequest(await Sending.GetWeatherInfo(), deviceId, MessageType.WeatherData); ;
                                var weatherBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(weatherInfo)));
                                await client.SendAsync(weatherBuffer, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
                                Console.WriteLine("Đã gửi");
                                break;
                            case MessageType.DeviceInfo:
                                Data.keyValuePairs[data.Id].Status = data.Status;
                                Console.WriteLine(Print(Data.keyValuePairs[data.Id]));
                                break;
                            default:                            
                                await Console.Out.WriteLineAsync("Invalid message");
                                break;
                        }
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine("Received close message, closing WebSocket.");
                        await client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                        Console.WriteLine("WebSocket connection closed successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception encountered: " + ex.Message);
            }
            
        }
    }
}


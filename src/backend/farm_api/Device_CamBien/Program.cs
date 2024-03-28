using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

#region Class Info
public class SensorData
{
    public float Temperature { get; set; }
    public float Humidity { get; set; }
    // ... Thêm các thuộc tính khác biểu diễn dữ liệu cảm biến
}

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
    private readonly static string DefaultLanguage = "en";
    private readonly static string ApiUrl = $"https://api.weatherapi.com/v1/current.json?q={Location}&lang={DefaultLanguage}&key={ApiKey}";
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
                    var  responseBody =  await response.Content.ReadAsStringAsync();
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
                throw new ();
            }
        }
    }
}
#endregion
public class DeviceInfo
{
    public DeviceInfo() { }
    public string DeviceName { get; set; }= "Sensor";
    public string DeviceVersion { get; set; }= "Sensor.V1.02";
    public string Type { get; set; } = "Sensor";
}
public class Program
{
    public static async Task Main(string[] args)
    {



       var response= await  Sending.GetWeatherInfo();


        using (ClientWebSocket client = new ClientWebSocket())
        {
            await client.ConnectAsync(new Uri("wss://localhost:7171/ws"), CancellationToken.None);
            Console.WriteLine("WebSocket client connected.");
            var DeviceInfo = new DeviceInfo();

            var sendBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)));
            await client.SendAsync(sendBuffer, WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);

            // Buffer for receiving chunks of data
            var receiveBuffer = new byte[1024 * 4];

            while (client.State == WebSocketState.Open)
            {
                // ReceiveAsync returns result which includes the message type, length, and whether the end of the message has been reached
                WebSocketReceiveResult result = await client.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);

                // Check if the server sent a text message
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    // Get the message as a string
                    var message = Encoding.UTF8.GetString(receiveBuffer, 0, result.Count);

                    // Process the message received from server
                    Console.WriteLine("Message received from server: " + message);

                    // TODO: Deserialize the message to a specific object if necessary
                    //var deviceInfo = JsonConvert.DeserializeObject<DeviceInfo>(message);
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    // Handle the close message from the server
                    await client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    Console.WriteLine("WebSocket connection closed successfully.");
                }

                // Optionally, reset the receiveBuffer or reuse it since you are now done processing the message
            }
        }
    }
}

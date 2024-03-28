using farm_api.Models;
using System.Collections.Concurrent;
using System.Net.Sockets;

namespace farm_api.Services.Implementation
{
    public class SocketResultManagement
    {
        private ConcurrentDictionary<string, WeatherData> _socketSensorResult = new ConcurrentDictionary<string, WeatherData>();
        public void AddSocketResultOrUpdate(string connectionId,WeatherData value)
        {
           var result = _socketSensorResult.AddOrUpdate(connectionId, value, (key, oldValue) => value);
            Console.WriteLine("WebSocket result updated or added for connectionId: " + connectionId);
        }
        public async Task<WeatherData> GetWeatherData(string connectionId)
        {
            var result = _socketSensorResult.TryGetValue(connectionId,out WeatherData weatherData);
            return weatherData;
        }
    }
}

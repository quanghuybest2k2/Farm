using device_sensor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace device_sensor.Devices
{
    public class DevicesList
    {
        public List<Device> Devices { get; set; }
    }
    public static class Data
    {

        public static ConcurrentDictionary<string, Device> keyValuePairs = DataJson();
        private static ConcurrentDictionary<string, Device> DataJson()
        {
            ConcurrentDictionary<string, Device> keyValuePairs = new ConcurrentDictionary<string, Device>();
            string jsonString =
                @"
                {
                    ""devices"": [
        {
          ""id"": ""F1"",
          ""name"": ""F1"",
          ""type"": ""fan"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773168"",
          ""updateAt"": ""2024-04-01T21:45:43.8773167"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""F2"",
          ""name"": ""F2"",
          ""type"": ""fan"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773172"",
          ""updateAt"": ""2024-04-01T21:45:43.8773171"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""F3"",
          ""name"": ""F3"",
          ""type"": ""fan"",
          ""status"": false,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773175"",
          ""updateAt"": ""2024-04-01T21:45:43.8773175"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""F4"",
          ""name"": ""F4"",
          ""type"": ""fan"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773179"",
          ""updateAt"": ""2024-04-01T21:45:43.8773178"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""F5"",
          ""name"": ""F5"",
          ""type"": ""fan"",
          ""status"": false,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773182"",
          ""updateAt"": ""2024-04-01T21:45:43.8773181"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""F6"",
          ""name"": ""F6"",
          ""type"": ""fan"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773185"",
          ""updateAt"": ""2024-04-01T21:45:43.8773184"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""F7"",
          ""name"": ""F7"",
          ""type"": ""fan"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773188"",
          ""updateAt"": ""2024-04-01T21:45:43.8773187"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""L1"",
          ""name"": ""L1"",
          ""type"": ""light"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8772895"",
          ""updateAt"": ""2024-04-01T21:45:43.877282"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""L2"",
          ""name"": ""L2"",
          ""type"": ""light"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773144"",
          ""updateAt"": ""2024-04-01T21:45:43.8773143"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""L3"",
          ""name"": ""L3"",
          ""type"": ""light"",
          ""status"": false,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773149"",
          ""updateAt"": ""2024-04-01T21:45:43.8773148"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""L4"",
          ""name"": ""L4"",
          ""type"": ""light"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773152"",
          ""updateAt"": ""2024-04-01T21:45:43.8773152"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""L5"",
          ""name"": ""L5"",
          ""type"": ""light"",
          ""status"": false,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773155"",
          ""updateAt"": ""2024-04-01T21:45:43.8773155"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""L6"",
          ""name"": ""L6"",
          ""type"": ""light"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773158"",
          ""updateAt"": ""2024-04-01T21:45:43.8773158"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""L7"",
          ""name"": ""L7"",
          ""type"": ""light"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8773162"",
          ""updateAt"": ""2024-04-01T21:45:43.8773161"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        },
        {
          ""id"": ""sensor-0"",
          ""name"": ""S1"",
          ""type"": ""sensor"",
          ""status"": true,
          ""connectionStatus"": false,
          ""createAt"": ""2024-04-01T21:45:43.8772136"",
          ""updateAt"": ""2024-04-01T21:45:43.8770202"",
          ""farmId"": ""2ae5e786-48ec-4f13-b842-af68c8b148b9""
        }
      ]
                }
                ";
            var devicesList = JsonConvert.DeserializeObject<DevicesList>(jsonString);

            if (devicesList != null && devicesList.Devices != null)
            {
                foreach (var device in devicesList.Devices)
                {
                    keyValuePairs[device.Id] = device;
                }
            }
            return keyValuePairs;
        }
    }
    
}

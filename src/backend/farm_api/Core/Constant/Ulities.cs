using Core.DTO;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Core.Constant
{
    public static class Ulities
    {
        public static readonly  string  Sensor= "Sensor";
        public static  bool flag = true;

        public const string HostServerMQTTHiveMQ = "25b819a37cd6410aac50cb6c8093b3d2.s1.eu.hivemq.cloud";
        public const int PortServerMQTTHiveMQ = 8883;
        public const string ClientId = "HiChaoCau";
        public const string AccountMQTTHiveMQ = "farm3";
        public const string PasswordMQTTHiveMQ = "Admin@12345";

        public static string SerializeDeviceData(DeviceRequestToESP data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // Để JSON được format đẹp, thích hợp khi muốn in ra màn hình
            };
            return JsonSerializer.Serialize(data, options);
        }
        public static DeviceRequestToESP DeserializeDeviceData(string json)
        {
            return JsonSerializer.Deserialize<DeviceRequestToESP>(json);
        }
    }
}

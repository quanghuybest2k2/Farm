﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Enums.MessageSocket;

namespace Core.Common
{
    public class WebSocketMessage<T>
    {
        public string DeviceId { get; set; }
        public MessageType MessageType { get; set; }
        public T Data { get; set; }
        public WebSocketMessage(T data, string deviceId, MessageType type)
        {
            Data = data;
            DeviceId = deviceId;
            MessageType = type;
        }
        public static WebSocketMessage<T> SocketRequest<T>(T data, string deviceId, MessageType type)
        {
            return new WebSocketMessage<T>(data, deviceId, type);
        }
    }
}

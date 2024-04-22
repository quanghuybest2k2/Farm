using Core.Constant;
using Core.DTO;
using farm_api.Hub;
using farm_api.Models.Request;
using farm_api.Services.Interface;
using Microsoft.AspNetCore.SignalR;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// <summary>
/// Manages MQTT client interactions including connection, subscription, and message handling for a farming application.
/// </summary>
public class MQTTService : IMQTTService
{
    private readonly ILogger<MQTTService> _logger;
    private readonly IMqttClient _client;
    private MqttClientOptions _options;
    private readonly IHubContext<FarmHub> _hubContext;
    private bool _isConnected;

    public bool IsConnected { get { return _isConnected; } }

    /// <summary>
    /// Initializes a new instance of the MQTTService with dependency injection for the SignalR hub context and logger.
    /// </summary>
    [Obsolete]
    public MQTTService(IHubContext<FarmHub> hubContext, ILogger<MQTTService> logger)
    {
        Console.OutputEncoding = Encoding.UTF8;
        _logger = logger;
        _hubContext = hubContext;
        var factory = new MqttFactory();
        _client = factory.CreateMqttClient();

        _options = new MqttClientOptionsBuilder()
            .WithClientId(Guid.NewGuid().ToString())
            .WithTcpServer(Ulities.HostServerMQTTHiveMQ, Ulities.PortServerMQTTHiveMQ)
            .WithCredentials(Ulities.AccountMQTTHiveMQ, Ulities.PasswordMQTTHiveMQ)
            .WithTls()
            .Build() as MqttClientOptions;
        _client.ConnectedAsync += HandleConnectedAsync;
        _client.DisconnectedAsync += HandleDisconnectedAsync;
        _client.ApplicationMessageReceivedAsync += HandleReceivedMessageAsync;
    }

    // Region for handling MQTT events such as connection, disconnection and message reception.
    #region handler event MQTT (connected, disconnected, ReceivedMessage)
    private async Task HandleConnectedAsync(MqttClientConnectedEventArgs e)
    {
        _isConnected = true;
        // Subscribe to topics upon connection.
        await SubscribeToTopicsAsync();
        _logger.LogInformation($"Connected to MQTT broker at {Ulities.HostServerMQTTHiveMQ}:{Ulities.PortServerMQTTHiveMQ}");
    }

    private async Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs e)
    {
        _isConnected = false;
        _logger.LogInformation($"Disconnected from MQTT broker at {Ulities.HostServerMQTTHiveMQ}:{Ulities.PortServerMQTTHiveMQ}");
    }

    private async Task HandleReceivedMessageAsync(MqttApplicationMessageReceivedEventArgs e)
    {
        string messagePayload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
        // Log and forward the message to all clients via SignalR.
        await _hubContext.Clients.All.SendAsync(e.ApplicationMessage.Topic, messagePayload);
        _logger.LogInformation($"Message sent to FE with topic: {e.ApplicationMessage.Topic}");
    }
    #endregion

    /// <summary>
    /// Connects the MQTT client to the broker with configured options.
    /// </summary>
    public async Task ConnectAsync()
    {
        try
        {
            await _client.ConnectAsync(_options);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Connection failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Disconnects the MQTT client from the broker.
    /// </summary>
    public async Task DisconnectAsync()
    {
        await _client.DisconnectAsync();
    }

    /// <summary>
    /// Subscribes the MQTT client to a specified topic.
    /// </summary>
    public async Task SubscribeAsync(string topic)
    {
        var topicFilter = new MqttTopicFilter { Topic = topic, QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce };
        await _client.SubscribeAsync(topicFilter);
        _logger.LogInformation($"Subscribed to topic {topic}");
    }

    /// <summary>
    /// Unsubscribes the MQTT client from a specified topic.
    /// </summary>
    public async Task UnsubscribeAsync(string topic)
    {
        await _client.UnsubscribeAsync(topic);
        _logger.LogInformation($"Unsubscribed from topic {topic}");
    }

    /// <summary>
    /// Publishes a message to a specified topic.
    /// </summary>
    public async Task PublishAsync(string topic, DeviceRequestToESP payload)
    {
        string messagePayload = Ulities.SerializeDeviceData(payload);
        var message = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(messagePayload)
            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
            .Build();

        await _client.PublishAsync(message);
        _logger.LogInformation($"Published message to {topic}");
    }

    /// <summary>
    /// Handles incoming messages for direct processing.
    /// </summary>
    public void HandleReceivedMessage(MqttApplicationMessageReceivedEventArgs e)
    {
        _logger.LogInformation($"Received message on topic: {e.ApplicationMessage.Topic}");
    }

    /// <summary>
    /// Initializes and connects the MQTT client, typically called at application startup.
    /// </summary>
    public async Task InitializeAsync()
    {
        try
        {
            await ConnectAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Connection failed: {ex.Message}");
        }
    }

    /// <summary>
    /// Subscribes to default topics after establishing a connection.
    /// </summary>
    private async Task SubscribeToTopicsAsync()
    {
        var topics = new string[] { "esp8266/ledControl", "esp8266/ledStatus", "KV2" };
        foreach (var topic in topics)
        {
            await SubscribeAsync(topic);
        }
    }

    public async Task PublishAsync(string topic, object payload)
    {
        string messagePayload = Ulities.SerializeDeviceData(payload);
        var message = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(messagePayload)
            .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
            .Build();

        await _client.PublishAsync(message);
        _logger.LogInformation($"Published message to {topic}");
    }
}

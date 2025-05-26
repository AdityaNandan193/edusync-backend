using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using edusync_api.Model;

namespace edusync_api.Services
{
    public class QuizEventProducerService : IAsyncDisposable
    {
        private readonly EventHubProducerClient _producerClient;
        private readonly string _eventHubName;
        private readonly ILogger<QuizEventProducerService> _logger;

        public QuizEventProducerService(IConfiguration configuration, ILogger<QuizEventProducerService> logger)
        {
            _logger = logger;
            var eventHubsConfig = configuration.GetSection("AzureEventHubs");
            string connectionString = eventHubsConfig["ConnectionString"];
            _eventHubName = eventHubsConfig["EventHubName"];

            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(_eventHubName))
            {
                _logger.LogError("Azure Event Hubs connection string or event hub name is not configured. Cannot send events.");
                _producerClient = null;
            }
            else
            {
                try
                {
                    _producerClient = new EventHubProducerClient(connectionString, _eventHubName);
                    _logger.LogInformation($"Event Hub Producer initialized for hub: {_eventHubName}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to initialize Event Hub Producer client.");
                    _producerClient = null;
                }
            }
        }

        public async Task SendQuizAttemptEventAsync(QuizAttemptData data)
        {
            if (_producerClient == null)
            {
                _logger.LogWarning("Event Hub Producer client is not initialized. Cannot send event.");
                return;
            }

            try
            {
                string eventBody = JsonSerializer.Serialize(data);
                var eventData = new EventData(Encoding.UTF8.GetBytes(eventBody));
                await _producerClient.SendAsync(new[] { eventData });
                _logger.LogInformation($"Sent event for Quiz Attempt: {data.AttemptId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending event for Quiz Attempt: {data.AttemptId}");
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_producerClient != null)
            {
                try
                {
                    await _producerClient.DisposeAsync();
                    _logger.LogInformation("Event Hub Producer client disposed.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error disposing Event Hub Producer client.");
                }
            }
        }
    }
} 
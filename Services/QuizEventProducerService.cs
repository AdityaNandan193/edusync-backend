using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging; // Added for logging
using System;
using System.Text;
using System.Text.Json; // Added for JSON serialization
using System.Threading.Tasks;
using System.Collections.Generic;

public class QuizEventProducerService : IAsyncDisposable
{
    private readonly EventHubProducerClient _producerClient;
    private readonly string _eventHubName;
    private readonly ILogger<QuizEventProducerService> _logger; // Added logger

    public QuizEventProducerService(IConfiguration configuration, ILogger<QuizEventProducerService> logger)
    {
        _logger = logger; // Initialize logger
        var eventHubsConfig = configuration.GetSection("AzureEventHubs");
        string connectionString = eventHubsConfig["ConnectionString"];
        _eventHubName = eventHubsConfig["EventHubName"];

        if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(_eventHubName))
        {
             _logger.LogError("Azure Event Hubs connection string or event hub name is not configured. Cannot send events.");
             // Initialize producer client to null or handle this case appropriately
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
                 _producerClient = null; // Ensure client is null on failure
            }
        }
    }

    // Method to send a single quiz attempt event
    public async Task SendQuizAttemptEventAsync(QuizAttemptData data)
    {
        if (_producerClient == null)
        {
            _logger.LogWarning("Event Hub Producer client is not initialized. Cannot send event.");
            return; // Exit if client is not ready
        }

        try
        {
            // Serialize your data to JSON
            string eventBody = JsonSerializer.Serialize(data);
            var eventData = new EventData(Encoding.UTF8.GetBytes(eventBody));

            // Send the event
            await _producerClient.SendAsync(new[] { eventData });
            _logger.LogInformation($"Sent event for Quiz Attempt: {{AttemptId}}", data.AttemptId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error sending event for Quiz Attempt: {{AttemptId}}", data.AttemptId);
            // Implement robust error handling/retry logic here if needed
        }
    }

    // Dispose method to close the client when the application shuts down
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

// Define a simple class to structure the data you want to send
public class QuizAttemptData
{
    public Guid AttemptId { get; set; }
    public Guid AssessmentId { get; set; }
    public Guid UserId { get; set; }
    public int Score { get; set; }
    public DateTime AttemptDate { get; set; }
    // Add any other relevant data for real-time analytics (e.g., duration, correct answers count)
} 
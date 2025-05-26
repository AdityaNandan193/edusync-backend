using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduSyncAPI.Services
{
    public class EventHubService
    {
        private readonly string _connectionString;
        private readonly string _eventHubName;
        private readonly EventHubProducerClient _producerClient;

        public EventHubService(IConfiguration configuration)
        {
            _connectionString = configuration["EventHub:ConnectionString"];
            _eventHubName = configuration["EventHub:Name"];
            _producerClient = new EventHubProducerClient(_connectionString, _eventHubName);
        }

        public async Task SendResultEventAsync(object resultEvent)
        {
            string json = JsonSerializer.Serialize(resultEvent);
            using EventDataBatch eventBatch = await _producerClient.CreateBatchAsync();
            eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(json)));
            await _producerClient.SendAsync(eventBatch);
        }
    }
} 
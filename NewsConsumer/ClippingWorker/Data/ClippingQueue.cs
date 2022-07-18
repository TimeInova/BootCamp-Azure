using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using ClippingWorker.Models;

namespace ClippingWorker.Data
{
    public class ClippingQueue
    {
        private readonly IConfiguration configuration;
        private ClippingRepository repository;
        private IModel channel;
        private EventingBasicConsumer consumer;

        public ClippingQueue(ClippingRepository _repository, IConfiguration _configuration)
        {
            repository = _repository;
            configuration = _configuration;
        }

        public void CreateConnectionNews(){
            var factory = new ConnectionFactory() { HostName = configuration.GetValue<string>("RabbitMQ") };
            var connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
            this.channel.QueueDeclare("news", false, false, false, null);
            this.consumer = new EventingBasicConsumer(this.channel);
            this.consumer.Received += (model, ea) => {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                IEnumerable<News>? news = JsonSerializer.Deserialize<IEnumerable<News>>(message);
                repository.SaveClippingNewsAsync(news);
            };
        }

        public void CreateConnectionComments(){
            var factory = new ConnectionFactory() { HostName = configuration.GetValue<string>("RabbitMQ") };
            var connection = factory.CreateConnection();
            this.channel = connection.CreateModel();
            this.channel.QueueDeclare("comments", false, false, false, null);
            this.consumer = new EventingBasicConsumer(this.channel);
            this.consumer.Received += (model, ea) => {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                IEnumerable<Comments>? comments = JsonSerializer.Deserialize<IEnumerable<Comments>>(message);
                repository.SaveClippingCommentsAsync(comments);
            };
        }

        public void ReceiveNews(){
            this.channel.BasicConsume("news", true, consumer);        
        }

        public void ReceiveComments(){
            this.channel.BasicConsume("comments", true, consumer);        
        }
    }
}
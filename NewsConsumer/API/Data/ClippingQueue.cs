using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using API.Data.Interfaces;
using API.Models;

namespace API.Data
{
    public class ClippingQueue : IClippingQueue
    {
        private readonly IConfiguration configuration;

        public ClippingQueue(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void sendNews(IEnumerable<NewsMessage> news)
        {
            var factory = new ConnectionFactory() { HostName = configuration.GetValue<string>("RabbitMQ") };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel()){
                channel.QueueDeclare("news", false, false, false, null);
                String newsJson = JsonSerializer.Serialize<IEnumerable<NewsMessage>>(news);
                var message = Encoding.UTF8.GetBytes(newsJson);
                channel.BasicPublish("", "news", null, message);
            }
        }

        public void sendComments(IEnumerable<CommentsMessage> comments)
        {
            var factory = new ConnectionFactory() { HostName = configuration.GetValue<string>("RabbitMQ") };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel()){
                channel.QueueDeclare("comments", false, false, false, null);
                String commentsJson = JsonSerializer.Serialize<IEnumerable<CommentsMessage>>(comments);
                var message = Encoding.UTF8.GetBytes(commentsJson);
                channel.BasicPublish("", "comments", null, message);
            }
        }

    }
}
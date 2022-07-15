using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using ClippingWorker.Models;
using ClippingWorker.Data;

namespace ClippingWorker.Workers
{
    public class WorkerNews : BackgroundService
    {
        private readonly ILogger<WorkerNews> logger;
        private readonly ClippingRepository repository;
        private readonly ClippingQueue queue;

        public WorkerNews(ClippingQueue _queue, ClippingRepository _repository, ILogger<WorkerNews> _logger)
        {
            queue = _queue;
            repository = _repository;
            logger = _logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            queue.CreateConnectionNews();

            while (!stoppingToken.IsCancellationRequested)
            {
                queue.ReceiveNews();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
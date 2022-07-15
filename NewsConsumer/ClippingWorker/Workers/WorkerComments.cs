using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using ClippingWorker.Models;
using ClippingWorker.Data;

namespace ClippingWorker.Workers
{
    public class WorkerComments : BackgroundService
    {
        private readonly ILogger<WorkerComments> logger;
        private readonly ClippingRepository repository;
        private readonly ClippingQueue queue;

        public WorkerComments(ClippingQueue _queue, ClippingRepository _repository, ILogger<WorkerComments> _logger)
        {
            queue = _queue;
            repository = _repository;
            logger = _logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            queue.CreateConnectionComments();

            while (!stoppingToken.IsCancellationRequested)
            {
                queue.ReceiveComments();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
using ClippingWorker.Workers;
using ClippingWorker.Data;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<WorkerNews>();
        services.AddHostedService<WorkerComments>();
        services.AddSingleton<ClippingRepository>();
        services.AddSingleton<ClippingQueue>();
    })
    .Build();

await host.RunAsync();
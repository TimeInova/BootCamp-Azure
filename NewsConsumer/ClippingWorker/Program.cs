using ClippingWorker.Workers;
using ClippingWorker.Data;
using MongoDB.Driver;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<WorkerNews>();
        services.AddHostedService<WorkerComments>();
        //services.AddSingleton<IMongoClient>(new MongoClient());
        services.AddSingleton<ClippingRepository>();
        services.AddSingleton<ClippingQueue>();
    })
    .Build();

await host.RunAsync();
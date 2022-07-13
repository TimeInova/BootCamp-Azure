using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using API.Models;
using API.Data.Interfaces;

namespace API.Data
{
    public class NewsRepository : INewsRepository
    {
        private readonly IMongoCollection<News> NewsCollection;

        public NewsRepository(IOptions<NewsConsumerDbSettings> settings){        
            MongoClientSettings settingsMongo = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
            settingsMongo.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
            NewsCollection =  mongoDatabase.GetCollection<News>("News");
        }

        public async Task CreateAsync(News news) =>
            await NewsCollection.InsertOneAsync(news);
        
        public async Task<List<News>> GetAllAsync() => 
            await NewsCollection.Find(_ => true).ToListAsync();
    }
}
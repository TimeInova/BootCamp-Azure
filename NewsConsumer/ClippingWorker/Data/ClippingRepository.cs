using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using ClippingWorker.Data.Interfaces;
using ClippingWorker.Models;

namespace ClippingWorker.Data
{
    public class ClippingRepository : IClippingRepository
    {
        private readonly IMongoCollection<News> NewsCollection;
        private readonly IMongoCollection<Comments> CommentsCollection;

        public ClippingRepository(){        
            MongoClientSettings settingsMongo = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
            settingsMongo.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("NewsConsumer");
            NewsCollection =  mongoDatabase.GetCollection<News>("News");
            CommentsCollection = mongoDatabase.GetCollection<Comments>("Comments");
        }

        public async Task SaveClippingNewsAsync(IEnumerable<News> news) => 
            await NewsCollection.InsertManyAsync(news);

        public async Task SaveClippingCommentsAsync(IEnumerable<Comments> comments) =>
            await CommentsCollection.InsertManyAsync(comments);
    }
}
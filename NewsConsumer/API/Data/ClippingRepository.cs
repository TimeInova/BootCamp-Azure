using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using API.Models;
using API.Data.Interfaces;

namespace API.Data
{
    public class ClippingRepository : IClippingRepository
    {
        private readonly IMongoCollection<NewsMessage> NewsCollection;
        private readonly IMongoCollection<CommentsMessage> CommentsCollection;

        public ClippingRepository(IOptions<ClippingDbSettings> settings){        
            MongoClientSettings settingsMongo = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
            settingsMongo.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
            NewsCollection =  mongoDatabase.GetCollection<NewsMessage>("News");
            CommentsCollection = mongoDatabase.GetCollection<CommentsMessage>("Comments");
        }

        public async Task<List<NewsMessage>> GetAllNewsAsync() => 
            await NewsCollection.Find(_ => true).ToListAsync();
        
        public async Task<List<CommentsMessage>> GetAllComentsAsync() => 
            await  CommentsCollection.Find(_ => true).ToListAsync();
    }
}
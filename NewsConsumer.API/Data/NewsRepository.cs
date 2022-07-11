using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Security.Authentication;

namespace NewsConsumer.API.Data
{
    public class NewsRepository
    {
        public NewsRepository(IOptions<NewsConsumerDbSettings> settings){        
            MongoClientSettings settingsMongo = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
            settingsMongo.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
        }
    }
}
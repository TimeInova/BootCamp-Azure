using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using API.Data.Interfaces;
using NewsConsumerAPI.Models;

namespace API.Data
{
    public class ClippingRepository : IClippingRepository
    {
        private readonly IMongoCollection<NewsMessage> newsCollection;

        public ClippingRepository(IOptions<ClippingDbSettings> settings){        
            MongoClientSettings settingsMongo = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
            settingsMongo.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
            newsCollection =  mongoDatabase.GetCollection<NewsMessage>("News");
        }

		public async Task<List<NewsMessage>> GetAllNewsAsync(int? maxResults)
		{
			var query = newsCollection.Find(_ => true);

			if (maxResults.HasValue)
				query.Limit(maxResults);

			return await query.ToListAsync();
		}


		public async Task InsertAllAsync(List<NewsMessage> messages)
		{
			var ids = messages.Select(x => x.IdTwitter).ToList();

			var existing = await newsCollection.Find(x => ids.Contains(x.IdTwitter)).ToListAsync();
			var existingIds = existing.Select(x => x.IdTwitter).ToList();

			messages.RemoveAll(x => existingIds.Contains(x.IdTwitter));

			if (messages.Any())
				await newsCollection.InsertManyAsync(messages);
		}
	}
}
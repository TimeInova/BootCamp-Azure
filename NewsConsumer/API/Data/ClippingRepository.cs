using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using API.Data.Interfaces;
using NewsConsumerAPI.Models;

namespace API.Data
{
    public class ClippingRepository : IClippingRepository
    {
		private readonly IMongoCollection<News> newsCollection;
		private readonly IMongoCollection<Comments> commentsCollection;

		public ClippingRepository(IOptions<ClippingDbSettings> settings){
			MongoClientSettings settingsMongo = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
			settingsMongo.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
			var mongoClient = new MongoClient(settings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
			newsCollection = mongoDatabase.GetCollection<News>("News");
			commentsCollection = mongoDatabase.GetCollection<Comments>("Comments");
		}

		public async Task<List<News>> GetAllNewsAsync(int? maxResults)
		{
			var query = newsCollection.Find(_ => true);

			if (maxResults.HasValue)
				query.Limit(maxResults);

			return await query.ToListAsync();
		}

		public async Task<List<Comments>> GetAllComentsAsync(int? maxResults)
		{
			var query = commentsCollection.Find(_ => true);

			if (maxResults.HasValue)
				query.Limit(maxResults);

			return await query.ToListAsync();
		}


		public async Task SaveClippingNews(List<News> news)
		{
			var ids = news.Select(x => x.IdTwitter).ToList();

			var existing = await newsCollection.Find(x => ids.Contains(x.IdTwitter)).ToListAsync();
			var existingIds = existing.Select(x => x.IdTwitter).ToList();

			news.RemoveAll(x => existingIds.Contains(x.IdTwitter));

			if (news.Any())
				await newsCollection.InsertManyAsync(news);
		}

		public async Task SaveClippingComments(List<Comments> comments)
		{
			var ids = comments.Select(x => x.IdTwitter).ToList();

			var existing = await commentsCollection.Find(x => ids.Contains(x.IdTwitter)).ToListAsync();
			var existingIds = existing.Select(x => x.IdTwitter).ToList();

			comments.RemoveAll(x => existingIds.Contains(x.IdTwitter));

			if (comments.Any())
				await commentsCollection.InsertManyAsync(comments);
		}
	}
}
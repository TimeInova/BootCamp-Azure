using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using API.Data.Interfaces;
using Azure.AI.TextAnalytics;

namespace API.Data.Repository
{
    public class AnalyzeRepository : IAnalyzeRepository
    {
		private readonly IMongoCollection<AnalyzeSentimentResultCollection> analyzeCollection;
		
		public AnalyzeRepository(IOptions<AnalyzeDbSettings> settings) {
			MongoClientSettings settingsMongo = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
			settingsMongo.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
			var mongoClient = new MongoClient(settings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
			analyzeCollection = mongoDatabase.GetCollection<AnalyzeSentimentResultCollection>("ResultAnalyze");
		}

        public async Task SaveResultAnalyze(AnalyzeSentimentResultCollection analyze) =>
            await analyzeCollection.InsertOneAsync(analyze);

        public async Task<List<AnalyzeSentimentResultCollection>> GetAllAnalyzesAsync(int? maxResults)
        {
            var query = analyzeCollection.Find(_ => true);

            if (maxResults.HasValue)
				query.Limit(maxResults);

			return await query.ToListAsync();
        }
    }
}

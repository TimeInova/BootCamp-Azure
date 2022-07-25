using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System.Security.Authentication;
using API.Data.Interfaces;
using API.Models;

namespace API.Data.Repository
{
    public class AnalyzeRepository : IAnalyzeRepository
    {
		private readonly IMongoCollection<ResultAnalyze> analyzeCollection;
		
		public AnalyzeRepository(IOptions<AnalyzeDbSettings> settings) {
			MongoClientSettings settingsMongo = MongoClientSettings.FromUrl(new MongoUrl(settings.Value.ConnectionString));
			settingsMongo.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
			var mongoClient = new MongoClient(settings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
			analyzeCollection = mongoDatabase.GetCollection<ResultAnalyze>("ResultAnalyze");
		}

        public async Task SaveResultAnalyze(ResultAnalyze analyze) =>
            await analyzeCollection.InsertOneAsync(analyze);

        public async Task<List<ResultAnalyze>> GetAllAnalyzesAsync(int? maxResults)
        {
            var query = analyzeCollection.Find(_ => true);

            if (maxResults.HasValue)
				query.Limit(maxResults);

			return await query.ToListAsync();
        }
    }
}

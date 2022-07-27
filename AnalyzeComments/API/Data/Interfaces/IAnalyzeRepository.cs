using Azure.AI.TextAnalytics;

namespace API.Data.Interfaces
{
    public interface IAnalyzeRepository
    {
		public Task SaveResultAnalyze(AnalyzeSentimentResultCollection analyze);
		public Task<List<AnalyzeSentimentResultCollection>> GetAllAnalyzesAsync(int? maxResults);
	}
}
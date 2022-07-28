using API.Models;
using Azure.AI.TextAnalytics;

namespace API.Data.Interfaces
{
    public interface IAnalyzeRepository
    {
		public Task SaveResultAnalyze(AnalyzeSentimentResultCollection analyze);
		public Task<List<ResultAnalyze>> GetAllAnalyzesAsync(int? maxResults);
	}
}
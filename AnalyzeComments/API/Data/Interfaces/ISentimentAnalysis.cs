using API.DTO;
using Azure.AI.TextAnalytics;

namespace API.Data.Interfaces
{
    public interface ISentimentAnalysis
    {
		public Task<AnalyzeSentimentResultCollection> ExecuteAnalyzeAsync(List<Comments> comments);
	}
}
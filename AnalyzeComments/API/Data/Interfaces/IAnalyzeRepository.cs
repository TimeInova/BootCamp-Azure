using API.Models;

namespace API.Data.Interfaces
{
    public interface IAnalyzeRepository
    {
		public Task SaveResultAnalyze(ResultAnalyze analyze);
		public Task<List<ResultAnalyze>> GetAllAnalyzesAsync(int? maxResults);
	}
}
using API.Models;

namespace API.Data.Interfaces
{
    public interface IClippingRepository
    {
		public Task SaveClippingNews(List<News> news);
		public Task SaveClippingComments(List<Comments> comments);
		public Task<List<News>> GetAllNewsAsync(int? maxResults);
		public Task<List<Comments>> GetAllComentsAsync(int? maxResults);
	}
}
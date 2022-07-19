using API.Models;

namespace API.Data.Interfaces
{
    public interface IClippingRepository
    {
        public Task SaveClippingNews(IEnumerable<News> news);
        public Task SaveClippingComments(IEnumerable<Comments> comments);
        public Task<List<News>> GetAllNewsAsync();
        public Task<List<Comments>> GetAllComentsAsync();
    }
}
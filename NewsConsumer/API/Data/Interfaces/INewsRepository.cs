using API.Models;

namespace API.Data.Interfaces
{
    public interface INewsRepository
    {
        public Task SaveClippingNewsAsync(IEnumerable<News> news);
        public Task SaveClippingCommentsAsync(IEnumerable<Comments> comments);
        public Task<List<News>> GetAllNewsAsync();
        public Task<List<Comments>> GetAllComentsAsync();
    }
}
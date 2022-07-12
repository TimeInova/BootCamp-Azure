using NewsConsumerAPI.Models;

namespace NewsConsumerAPI.Data.Interfaces
{
    public interface INewsRepository
    {
        public Task<List<News>> GetAllAsync();
        public Task CreateAsync(News news);
    }
}
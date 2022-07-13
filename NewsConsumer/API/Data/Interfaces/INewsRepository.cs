using API.Models;

namespace API.Data.Interfaces
{
    public interface INewsRepository
    {
        public Task<List<News>> GetAllAsync();
        public Task CreateAsync(News news);
    }
}
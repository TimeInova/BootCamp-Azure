using API.Models;

namespace API.Data.Interfaces
{
    public interface IClippingRepository
    {
        public Task<List<NewsMessage>> GetAllNewsAsync();
        public Task<List<CommentsMessage>> GetAllComentsAsync();
    }
}
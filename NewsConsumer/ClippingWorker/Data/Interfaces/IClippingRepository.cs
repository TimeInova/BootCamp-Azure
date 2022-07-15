using ClippingWorker.Models;

namespace ClippingWorker.Data.Interfaces
{
    public interface IClippingRepository
    {
        public Task SaveClippingNewsAsync(IEnumerable<News> news);
        public Task SaveClippingCommentsAsync(IEnumerable<Comments> comments);
    }
}
using API.Models;
using NewsConsumerAPI.Models;

namespace API.Data.Interfaces
{
    public interface IClippingRepository
    {
        public Task<List<NewsMessage>> GetAllNewsAsync(int? maxResults);
		public Task InsertAllAsync(List<NewsMessage> messages);
	}
}
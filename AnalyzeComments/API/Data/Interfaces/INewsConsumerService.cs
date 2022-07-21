using API.Models;

namespace API.Data.Interfaces
{
	public interface INewsConsumerService
	{
		Task<Comments?> GetComments(int? maxResults);
	}
}
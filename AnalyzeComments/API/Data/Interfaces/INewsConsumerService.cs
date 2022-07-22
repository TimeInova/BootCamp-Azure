using API.DTO;

namespace API.Data.Interfaces
{
	public interface INewsConsumerService
	{
		Task<List<Comments?>> GetComments();
	}
}
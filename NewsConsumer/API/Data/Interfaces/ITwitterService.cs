using API.Models;

namespace API.Data.Interfaces
{
	public interface ITwitterService
	{
		Task<TweetsResponse?> GetTweets(int? maxResults);
	}
}
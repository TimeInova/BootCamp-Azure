using NewsConsumerAPI.Models;

namespace NewsConsumerAPI.Data.Interfaces
{
	public interface ITwitterService
	{
		Task<TweetsResponse?> GetTweets(int? maxResults);
	}
}
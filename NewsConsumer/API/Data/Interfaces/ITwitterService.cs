using API.DTO;

namespace API.Data.Interfaces
{
	public interface ITwitterService
	{
		Task<TweetsResponse?> GetTweets(int? maxResults);
		Task<TweetsResponse?> GetTweetsComments(int? maxResults);
	}
}
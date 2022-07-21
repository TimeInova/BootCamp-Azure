using API.Data.Interfaces;
using API.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace API.Data.Services
{
	public class TwitterService : ITwitterService
	{
		private readonly IHttpClientFactory httpClientFactory;
		private readonly IConfiguration configuration;

		private const string TWEETS_URL = "https://api.twitter.com/2/users/68693419/tweets?";
		private const string TWEETS_COMMENTS_URL = "https://api.twitter.com/2/tweets/search/recent?query=Prefeitura de Curitiba?";
		public TwitterService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
		{
			this.httpClientFactory = httpClientFactory;
			this.configuration = configuration;
		}

		public async Task<TweetsResponse?> GetTweets(int? maxResults)
		{
			var token = configuration.GetValue<string>("Twitter:BearerToken");

			var url = TWEETS_URL;
			if (maxResults.HasValue)
				url += $"max_results={maxResults}";

			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

			httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var httpClient = httpClientFactory.CreateClient();
			var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

			if (httpResponseMessage.IsSuccessStatusCode)
			{
				var content = await httpResponseMessage.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<TweetsResponse>(content);

				return result;
			}
			else
			{
				var content = await httpResponseMessage.Content.ReadAsStringAsync();
				throw new Exception(content);
			}
		}

        public async Task<TweetsResponse?> GetTweetsComments(int? maxResults)
        {
            var token = configuration.GetValue<string>("Twitter:BearerToken");

			var url = TWEETS_COMMENTS_URL;
			if (maxResults.HasValue)
				url += $"max_results={maxResults}";

			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

			httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

			var httpClient = httpClientFactory.CreateClient();
			var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

			if (httpResponseMessage.IsSuccessStatusCode)
			{
				var content = await httpResponseMessage.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<TweetsResponse>(content);

				return result;
			}
			else
			{
				var content = await httpResponseMessage.Content.ReadAsStringAsync();
				throw new Exception(content);
			}
        }
    }
}

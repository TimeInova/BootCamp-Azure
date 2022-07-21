using Newtonsoft.Json;
using API.Data.Interfaces;
using API.DTO;

namespace API.Data.Services
{
    public class NewsConsumerService : INewsConsumerService
    {
        private readonly IHttpClientFactory httpClientFactory;
		private readonly IConfiguration configuration;

        public NewsConsumerService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
        }

        public async Task<Comments?> GetComments(int? maxResults)
        {
            var url = configuration.GetValue<string>("NewsConsumerAPI");

            if (maxResults.HasValue)
				url += $"max_results={maxResults}";

			var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

			var httpClient = httpClientFactory.CreateClient();
			var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

			if (httpResponseMessage.IsSuccessStatusCode)
			{
				var content = await httpResponseMessage.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<Comments>(content);

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
using Newtonsoft.Json;
using API.Data.Interfaces;
using API.DTO;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Options;
using Azure;

namespace API.Data.Services
{
    public class SentimentAnalysis : ISentimentAnalysis
    {
        private readonly IHttpClientFactory httpClientFactory;
		private readonly IOptions<IntegrationSettings> settings;

        public SentimentAnalysis(IHttpClientFactory httpClientFactory, IOptions<IntegrationSettings> settings)
        {
            this.httpClientFactory = httpClientFactory;
            this.settings = settings;
            
        }
        public async Task<AnalyzeSentimentResultCollection> ExecuteAnalyzeAsync(List<Comments> comments)
        {   
            var client = new TextAnalyticsClient(new Uri(settings.Value.Endpoint), new AzureKeyCredential(settings.Value.ApiKey));

            var documents = new List<string>();
            
            foreach (var comment in comments)
            {
                documents.Add(comment.Text);   
            }

           return await client.AnalyzeSentimentBatchAsync(documents);
        }
    }
}
using Newtonsoft.Json;
using API.Data.Interfaces;
using API.DTO;
using Azure.AI.TextAnalytics;
using Azure;

namespace API.Data.Services
{
    public class SentimentAnalysis : ISentimentAnalysis
    {
        private readonly IHttpClientFactory httpClientFactory;
		private readonly IConfiguration configuration;

        public SentimentAnalysis(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;            
        }
        public async Task<AnalyzeSentimentResultCollection> ExecuteAnalyzeAsync(List<Comments> comments)
        {   
            var endpoint = configuration.GetValue<string>("AzureCognitiveServices:Endpoint");
            var apikey = configuration.GetValue<string>("AzureCognitiveServices:ApiKey");
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apikey));

            var documents = new List<string>();
            
            foreach (var comment in comments)
            {
                documents.Add(comment.Text);   
            }

           return await client.AnalyzeSentimentBatchAsync(documents);
        }
    }
}
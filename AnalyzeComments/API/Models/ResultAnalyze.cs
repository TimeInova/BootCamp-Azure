using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Azure.AI.TextAnalytics;

namespace API.Models
{
    public class ResultAnalyze
    {
        public ResultAnalyze(AnalyzeSentimentResultCollection analyzeSentimentResults)
        {
            AnalyzeSentimentResults = analyzeSentimentResults;
            DateCollect = DateTime.Now;
        }

        [BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
        public AnalyzeSentimentResultCollection AnalyzeSentimentResults { get; set; }
        public DateTime DateCollect {get; set;}
    } 
}
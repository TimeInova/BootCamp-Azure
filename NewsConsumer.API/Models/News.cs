using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace NewsConsumer.API.Models
{
    public class News
    {

        public News()
        {
            DateCollect = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string? Id {get; set;}
        public string? Text {get; set;}
        public DateTime DateCollect {get; set;}

    }
}
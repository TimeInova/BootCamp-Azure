using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using API.DTO;

namespace API.Models
{
    public class News
    {
        public News(TweetData data)
        {
			IdTwitter = data.Id;
			Text = data.Text;
			DateCollect = DateTime.Now;
        }


		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
		public string? IdTwitter {get; set;}
        public string? Text {get; set;}
        public DateTime DateCollect {get; set;}
    }
}
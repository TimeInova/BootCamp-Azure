using API.DTO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class Comments
    {
        public Comments(TweetData data)
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
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class ResultAnalyze
    {
        public ResultAnalyze()
        {
            DateCollect = DateTime.Now;
        }

        [BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

        //Entender estrutura do resultado da analyze para definir models
        
        public DateTime DateCollect {get; set;}
    }
}
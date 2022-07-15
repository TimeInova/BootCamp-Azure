namespace API.Models
{
    public class NewsMessage
    {
        public NewsMessage()
        {
            DateCollect = DateTime.Now;
        }

        public string? IdTwitter {get; set;}
        public string? Text {get; set;}
        public DateTime DateCollect {get; set;}
    }
}
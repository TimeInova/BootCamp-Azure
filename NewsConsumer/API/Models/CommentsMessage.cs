namespace API.Models
{
    public class CommentsMessage
    {
        public CommentsMessage()
        {
            DateCollect = DateTime.Now;
        }

        public string? IdTwitter {get; set;}
        public string? Text {get; set;}
        public DateTime DateCollect {get; set;}
    }
}
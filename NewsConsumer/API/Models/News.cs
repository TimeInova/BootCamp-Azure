namespace API.Models
{
    public class News
    {
        public News()
        {
            DateCollect = DateTime.Now;
        }

        public string? IdTwitter {get; set;}
        public string? Text {get; set;}
        public DateTime DateCollect {get; set;}
    }
}
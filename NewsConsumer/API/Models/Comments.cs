namespace API.Models
{
    public class Comments
    {
        public Comments()
        {
            DateCollect = DateTime.Now;
        }

        public string? IdTwitter {get; set;}
        public string? Text {get; set;}
        public DateTime DateCollect {get; set;}
    }
}
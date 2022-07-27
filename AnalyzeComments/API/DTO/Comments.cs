namespace API.DTO
{
    public class Comments
    {
        public Comments(string text)
        {
            Text = text;
        }
        public string? IdTwitter {get; set;}
        public string Text {get; set;}
        public DateTime DateCollect {get; set;}
    }
}
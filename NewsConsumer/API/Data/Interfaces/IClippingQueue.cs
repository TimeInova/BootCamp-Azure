using API.Models;

namespace API.Data.Interfaces
{
    public interface IClippingQueue
    {
        void sendNews(IEnumerable<NewsMessage> news);
        void sendComments(IEnumerable<CommentsMessage> comments);        
    }
}
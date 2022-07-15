using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class NewsController
    {
        //private readonly ClippingQueue queue;
        private readonly ILogger<NewsController> logger;
        private readonly ClippingRepository repository;

        public NewsController(ClippingRepository _repository, ILogger<NewsController> _logger) // ClippingQueue _queue, 
        {
            //queue = _queue;
            repository = _repository;
            logger = _logger;
        }

        //Rota de solicitação de atualização das noticias
        [HttpPost("UpdateNews")]
        //async Task<ActionResult>
        public string ClippingNews() 
        {
            //Primeira etapa - chamar a api do twitter para baixar as noticias
            var newsTwitter = "rota em desenvolvimento"; //Aqui é a chamada para a api do twitter
            
            //Segunda etapa - Fazer o Deserialize dos dados
            //IEnumerable<NewsMessage>? message = JsonSerializer.Deserialize<IEnumerable<NewsMessage>>(newsTwitter);
            
            //Enviar para o Worker com RabbitMQ
            //queue.sendNews(message);
            
            return newsTwitter;
            //return Ok();
        }

        //Rota de solicitação de atualização de comentarios
        [HttpPost("UpdateComments")]
        //async Task<ActionResult>
        public string ClippingComments() 
        { 
            //Primeira etapa - chamar a api do twitter para baixar as noticias
            var commentsTwitter = "rota em desenvolvimento"; //Aqui é a chamada para a api do twitter
            
            //Segunda etapa - Fazer o Deserialize dos dados
            //IEnumerable<CommentsMessage>? message = JsonSerializer.Deserialize<IEnumerable<CommentsMessage>>(commentsTwitter);
            
            //Enviar para o Worker com RabbitMQ
            //queue.sendComments(message);
            
            return commentsTwitter;
            //return Ok();
        }

        //Rota de compartilhamento das noticias salvas no banco
        [HttpGet("GetAllNews")]
        public async Task<List<NewsMessage>> GetAllNews() => 
            await repository.GetAllNewsAsync();
        
        //Rota de compartilhamento de comentarios salvos no banco
        [HttpGet("GetAllComments")]
        public async Task<List<CommentsMessage>> GetAllComents() => 
            await repository.GetAllComentsAsync();
    }
}
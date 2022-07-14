using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class NewsController
    {
        private readonly ILogger<NewsController> logger;
        private readonly ClippingRepository repository;

        public NewsController(ClippingRepository _repository, ILogger<NewsController> _logger)
        {
            logger = _logger;
            repository = _repository;
        }

        //Rota de solicitação de atualização das noticias
        [HttpPost("UpdateNews")]
        //async Task<ActionResult>
        public string ClippingNews() 
        {
            //Primeira etapa - adiciona a fila Rabbitmq 
            //Segunda etapa - chamar a api do twitter para baixar as noticias
            //Salvar noticias no banco de dados

            //await repository.CreateAsync(news);
            return "rota em desenvolvimento";
            //return Ok();
        }

        //Rota de solicitação de atualização de comentarios
        [HttpPost("UpdateComments")]
        //async Task<ActionResult>
        public string ClippingComments() 
        {
            //Primeira etapa - adiciona a fila Rabbitmq 
            //Segunda etapa - chamar a api do twitter para baixar as noticias
            //Salvar noticias no banco de dados

            //await repository.CreateAsync(news);
            return "rota em desenvolvimento";
            //return Ok();
        }

        //Rota de compartilhamento das noticias salvas no banco
        [HttpGet("GetAllNews")]
        public async Task<List<News>> GetAllNews() => 
            await repository.GetAllNewsAsync();
        
        //Rota de compartilhamento de comentarios salvos no banco
        [HttpGet("GetAllComments")]
        public async Task<List<Comments>> GetAllComents() => 
            await repository.GetAllComentsAsync();
    }
}
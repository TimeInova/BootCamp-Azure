using Microsoft.AspNetCore.Mvc;
using NewsConsumerAPI.Data;
using NewsConsumerAPI.Models;

namespace NewsConsumerAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class NewsController
    {
        private readonly ILogger<NewsController> logger;
        private readonly NewsRepository repository;

        public NewsController(NewsRepository _repository, ILogger<NewsController> _logger)
        {
            logger = _logger;
            repository = _repository;
        }

        //Rota de compartilhamento das noticias salvas no banco
        [HttpGet("GetAllNews")]
        public async Task<List<News>> Get() => 
            await repository.GetAllAsync();

        //Rota de solicitação de atualização das noticias
        [HttpPost("UpdateNews")]
        //async Task<ActionResult>
        public string clipping() 
        {
            //Primeira etapa - adiciona a fila Rabbitmq 
            //Segunda etapa - chamar a api do twitter para baixar as noticias
            //Salvar noticias no banco de dados

            //await repository.CreateAsync(news);
            return "rota em desenvolvimento";
            //return Ok();
        }
        
    }
}
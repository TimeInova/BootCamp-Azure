using Microsoft.AspNetCore.Mvc;
using NewsConsumer.API.Data;
using NewsConsumer.API.Models;

namespace NewsConsumer.API.Controllers
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

        [HttpGet]
        public string teste() => "Hello World";
        //Adicionar rota de solicitação de atualização das noticias
        //Adicionar rota de compartilhamento das noticias salvas no banco

    }
}
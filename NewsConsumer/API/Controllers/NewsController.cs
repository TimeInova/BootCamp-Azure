using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.DTO;
using API.Data.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class NewsController : ControllerBase
    {
        private readonly ILogger<NewsController> logger;
		private readonly ITwitterService twitterService;
		private readonly IClippingRepository repository;

		public NewsController(ILogger<NewsController> logger, 
			ITwitterService twitterService, 
			IClippingRepository clippingRepository)
        {

            this.logger = logger;
			this.twitterService = twitterService;
			this.repository = clippingRepository;
		}

        //Rota de solicitação de atualização das noticias
        [HttpPost("UpdateNews")]
        public async Task<IActionResult> ClippingNews(int? maxResults = 10) 
        {
			try
			{
				var tweets = await twitterService.GetTweets(maxResults);

				if (tweets != null && tweets.Data != null)
				{
					var messages = tweets!.Data.Select(x => new News(x)).ToList();

					await repository.SaveClippingNews(messages);

					return Ok(tweets!.Data);
				}

				return NoContent();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

		}

		 //Rota de solicitação de atualização dos comentarios
        [HttpPost("UpdateComments")]
        //async Task<IActionResult>
		public string ClippingComments(int? maxResults = 10) 
        {
			var tweetsComments = "Rota em desenvolvimento"; //Aqui vai a integração para pegar comentários do twitter que mencionam "Prefeitura de Curitiba" 
			
			return tweetsComments;
		}

		//Rota de compartilhamento das noticias salvas no banco
		[HttpGet("GetNews")]
		public async Task<IActionResult> GetAllNews(int? maxResults = 10)
		{
			try
			{
				return Ok(await repository.GetAllNewsAsync(maxResults));
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		//Rota de compartilhamento dos comentarios salvos no banco
		[HttpGet("GetComments")]
		public async Task<IActionResult> GetAllComments(int? maxResults = 10)
		{
			try
			{
				return Ok(await repository.GetAllComentsAsync(maxResults));
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}


	}
}
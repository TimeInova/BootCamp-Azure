using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using API.Data;
using API.Models;
using NewsConsumerAPI.Data.Interfaces;
using API.Data.Interfaces;
using NewsConsumerAPI.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class NewsController : ControllerBase
    {
        //private readonly ClippingQueue queue;
        private readonly ILogger<NewsController> logger;
		private readonly ITwitterService twitterService;
		private readonly IClippingRepository repository;

		public NewsController(ILogger<NewsController> _logger, 
			ITwitterService twitterService, 
			IClippingRepository clippingRepository) // ClippingQueue _queue, 
        {
            //queue = _queue;
            logger = _logger;
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
					var messages = tweets!.Data.Select(x => new NewsMessage(x)).ToList();

					await repository.InsertAllAsync(messages);

					return Ok(tweets!.Data);
				}

				return NoContent();
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}

		}

		//Rota de compartilhamento das noticias salvas no banco
		[HttpGet("GetAllNews")]
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


	}
}
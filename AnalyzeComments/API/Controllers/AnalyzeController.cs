using Microsoft.AspNetCore.Mvc;
using API.Data.Services;
using API.Data.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class AnalyzeController : ControllerBase
    {
        private readonly ILogger<AnalyzeController> logger;
        private readonly IAnalyzeRepository repository;
        private readonly INewsConsumerService newsConsumerService;
        private readonly ISentimentAnalysis sentimentAnalysis;

        public AnalyzeController(ILogger<AnalyzeController> logger, 
            IAnalyzeRepository repository,
            INewsConsumerService newsConsumerService,
            ISentimentAnalysis sentimentAnalysis
            )
        {
            this.logger = logger;
            this.repository = repository;
            this.newsConsumerService = newsConsumerService;
            this.sentimentAnalysis = sentimentAnalysis;
        }

        [HttpPost("UpdateAnalyzes")]
        public async Task<IActionResult> UpdateAnalyzes()
        {
            try
            {
                var comments = await newsConsumerService.GetComments();
                var resultAnalyze = await sentimentAnalysis.ExecuteAnalyzeAsync(comments);
                await repository.SaveResultAnalyze(resultAnalyze);

                return Ok(comments);   
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetAnalyzes")]
        public async Task<IActionResult> GetAllAnayzes(int? maxResults = 10)
        {
            try
            {
                return Ok(await this.repository.GetAllAnalyzesAsync(maxResults));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
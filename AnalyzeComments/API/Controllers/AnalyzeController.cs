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

        public AnalyzeController(ILogger<AnalyzeController> logger, 
                                 IAnalyzeRepository repository,
                                 INewsConsumerService newsConsumerService)
        {
            this.logger = logger;
            this.repository = repository;
            this.newsConsumerService = newsConsumerService;
        }

        [HttpPost("UpdateAnalyzes")]
        //async Task<IActionResult>
        public string UpdateAnalyzes(int? maxResults)
        {
            try
            {
                var comments = newsConsumerService.GetComments(maxResults);
                //var resultAnalyze = AQUI A INTEGRAÇÃO COM A API DE ANALISE DA AZURE
                //await repository.SaveResultAnalyze(resultAnalyze);

                return "Rota em desenvolvimento";   
            }
            catch (System.Exception)
            {
                throw;
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
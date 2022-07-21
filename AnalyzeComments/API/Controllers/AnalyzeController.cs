using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api")]
    public class AnalyzeController : ControllerBase
    {
        private readonly ILogger<AnalyzeController> logger;
        private readonly IAnalyzeRepository repository;

        public AnalyzeController(ILogger<AnalyzeController> logger, IAnalyzeRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpPost("UpdateAnalyzes")]
        //async Task<IActionResult>
        public string UpdateAnalyzes()
        {
            //var comments = AQUI A INTEGRAÇÃ COM A API DE CLIPPING 
            //var resultAnalyzes = AQUI A INTEGRAÇÃO COM A API DE ANALISE DA AZURE
            
            return "Rota em desenvolvimento";
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
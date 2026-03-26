using EstudoDocker.Application.Interfaces;
using EstudoDocker.Application.Request;
using Microsoft.AspNetCore.Mvc;

namespace EstudoDocker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly IKafkaService _kafkaService;
        public PessoaController(IPessoaService pessoaService, IKafkaService kafkaService)
        {
            _pessoaService = pessoaService;
            _kafkaService = kafkaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var pessoa = await _pessoaService.GetAllAsync().ConfigureAwait(false);

            return Ok(pessoa);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(PessoaRequest pessoaRequest)
        {
            var status = await _kafkaService.ProducerMsgAsync(pessoaRequest).ConfigureAwait(false);
            if (status)
            {
                return Ok();
            }
            else
            {
                return BadRequest();

            }
               
        }
    }
}

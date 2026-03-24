using EstudoDocker.Application.Interfaces;
using EstudoDocker.DataBase.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstudoDocker.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var pessoa = await _pessoaService.GetAllAsync().ConfigureAwait(false);

            return Ok(pessoa);
        }
    }
}

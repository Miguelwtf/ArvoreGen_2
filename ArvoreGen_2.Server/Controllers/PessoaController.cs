using Microsoft.AspNetCore.Mvc;
using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Models;

namespace ArvoreGen_2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            var pessoas = await _pessoaService.ObterTodasPessoasAsync();
            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> CreatePessoa([FromBody] Pessoa pessoa)
        {
            var novaPessoa = await _pessoaService.CriarPessoaAsync(pessoa);
            return CreatedAtAction(nameof(GetPessoa), new { id = novaPessoa.IdPessoa}, novaPessoa);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _pessoaService.ObterPessoaPorIdAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoa(int id, [FromBody] Pessoa pessoa)
        {
            if (id != pessoa.IdPessoa)
            {
                return BadRequest();
            }

            var sucesso = await _pessoaService.AtualizarPessoaAsync(pessoa);
            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(int id)
        {
            var sucesso = await _pessoaService.RemoverPessoaAsync(id);
            if (!sucesso)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}

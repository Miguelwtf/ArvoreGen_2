using Microsoft.AspNetCore.Mvc;
using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ArvoreGen_2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        const string SINALIZADOR = " ##########################################################";

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        [Route("visualizar")]
        [Produces("application/json")]
        public async Task<IActionResult> Visualizar()
        {
            var pessoas = await _pessoaService.GetAll();
            return Ok(pessoas);
        }

        [HttpPost]
        [Route("adicionar")]
        [Consumes("application/json")]
        public async Task<IActionResult> Adicionar([FromBody] Pessoa novaPessoa)
        {
            if (novaPessoa == null)
            {
                return BadRequest("Os dados da pessoa são inválidos.");
            }
            Console.WriteLine(nameof(this.ToString) + " Adicionar " + SINALIZADOR);

            await _pessoaService.Adicionar(novaPessoa);
            return Ok("Pessoa adicionada com sucesso!");
        }

        [HttpGet]
        [Route("adicionarTeste")]
        public async Task<IActionResult> Teste([FromBody] Pessoa novaPessoa)
        {
            if (novaPessoa == null)
            {
                return BadRequest("Os dados da pessoa são inválidos.");
            }

            if (novaPessoa == null)
            {
                return BadRequest("Os dados da pessoa são inválidos.");
            }

            await _pessoaService.Adicionar(novaPessoa);
            return Ok("Pessoa adicionada com sucesso!");
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                bool resultado = await _pessoaService.Deletar(id);
                if (resultado)
                {
                    return Ok("Pessoa excluída com sucesso.");
                }
                else
                {
                    return NotFound("Pessoa não encontrada.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir a pessoa: {ex.Message}");
            }
        }
    }
}

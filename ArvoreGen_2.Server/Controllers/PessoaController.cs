using Microsoft.AspNetCore.Mvc;
using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Visualizar" + "\n" + SINALIZADOR);

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
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Adicionar" + "\n" + SINALIZADOR);

            await _pessoaService.Adicionar(novaPessoa);
            return Ok("Pessoa adicionada com sucesso!");
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {

            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Deletar" + "\n" + SINALIZADOR);

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

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Pessoa pessoa)
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Editar" + "\n" + SINALIZADOR);

            try
            {
                var resultado = await _pessoaService.Editar(id, pessoa);
                if (resultado)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound("Pessoa não encontrada.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar pessoa: {ex.Message}");
            }
        }

        /* Buscar todas as pessoas */
        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> ListarPessoas()
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - ListarPessoas" + "\n" + SINALIZADOR);

            try
            {
                var pessoas = await _pessoaService.ListarPessoa();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}

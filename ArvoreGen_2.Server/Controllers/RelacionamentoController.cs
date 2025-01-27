using Microsoft.AspNetCore.Mvc;
using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace ArvoreGen_2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelacionamentoController : ControllerBase
    {
        private readonly IRelacionamentoService _relacionamentoService;

        const string SINALIZADOR = " ##########################################################";

        public RelacionamentoController(IRelacionamentoService relacionamentoService)
        {
            _relacionamentoService = relacionamentoService;
        }

        [HttpGet]
        [Route("visualizar")]
        [Produces("application/json")]
        public async Task<IActionResult> Visualizar()
        {
            var relacionamentos = await _relacionamentoService.GetAll();
            return Ok(relacionamentos);
        }

        [HttpPost]
        [Route("adicionar")]
        [Consumes("application/json")]
        public async Task<IActionResult> Adicionar([FromBody] Relacionamento novoRelacionamento)
        {
            if (novoRelacionamento == null)
            {
                return BadRequest("Os dados da pessoa são inválidos.");
            }
            Console.WriteLine(nameof(this.ToString) + " Adicionar " + SINALIZADOR);

            await _relacionamentoService.Adicionar(novoRelacionamento);
            return Ok("Pessoa adicionada com sucesso!");
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                bool resultado = await _relacionamentoService.Deletar(id);
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
        public async Task<IActionResult> Editar(int id, [FromBody] Relacionamento relacionamento)
        {
            try
            {
                var resultado = await _relacionamentoService.Editar(id, relacionamento);
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

    }
}

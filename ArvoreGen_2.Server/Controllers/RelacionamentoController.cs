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
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Visualizar" + "\n" + SINALIZADOR);

            var relacionamentos = await _relacionamentoService.GetAll();
            return Ok(relacionamentos);
        }

        [HttpPost]
        [Route("adicionar")]
        [Consumes("application/json")]
        public async Task<IActionResult> Adicionar([FromBody] Relacionamento novoRelacionamento)
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Adicionar" + "\n" + SINALIZADOR);

            if (novoRelacionamento == null)
            {
                return BadRequest("Os dados da pessoa são inválidos.");
            }

            await _relacionamentoService.Adicionar(novoRelacionamento);
            return Ok("Pessoa adicionada com sucesso!");
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Deletar" + "\n" + SINALIZADOR);

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
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Editar" + "\n" + SINALIZADOR);

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

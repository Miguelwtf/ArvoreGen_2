using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ArvoreGen_2.Server.Models
{
    public class RelacionamentoService : IRelacionamentoService
    {
        private readonly ApplicationDbContext _context;

        const string SINALIZADOR = " ##########################################################";

        public RelacionamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /* Visualizar ------------------------- */
        public async Task<List<RelacionamentoDto>> GetAll()
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - GetAll" + "\n" + SINALIZADOR);

            // Aqui, incluímos os dados de Pessoa1 e Pessoa2
            var relacionamentos = await _context.Relacionamentos
                .Include(r => r.IdPessoa1)  // Inclui a Pessoa1
                .Include(r => r.IdPessoa2)  // Inclui a Pessoa2
                .Select(r => new RelacionamentoDto
                {
                    IdRelacionamento = r.IdRelacionamento,
                    Pessoa1Nome = r.IdPessoa1.Nome,  // Mapeia o nome de Pessoa1
                    Pessoa2Nome = r.IdPessoa2.Nome,  // Mapeia o nome de Pessoa2
                    TipoRelacionamento = r.TipoRelacionamento
                })
                .ToListAsync();

            return relacionamentos;
        }

        /* Adicionar ------------------------- */
        public async Task Adicionar(Relacionamento relacionamento)
        {
            _context.Relacionamentos.Add(relacionamento);

            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Adicionar" + "\n" + SINALIZADOR);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Deletar" + "\n" + SINALIZADOR);

            var relacionamento = await _context.Relacionamentos.FindAsync(id);
            if (relacionamento == null)
            {
                return false;
            }

            _context.Relacionamentos.Remove(relacionamento);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Editar(int id, Relacionamento relacionamento)
        {
            var relacionamentoExistente = await _context.Relacionamentos.FindAsync(id);
            if (relacionamentoExistente == null)
            {
                return false;
            }

            relacionamentoExistente.IdPessoa1 = relacionamento.IdPessoa1;
            relacionamentoExistente.IdPessoa2 = relacionamento.IdPessoa2;
            relacionamentoExistente.TipoRelacionamento = relacionamento.TipoRelacionamento;

            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Editar" + "\n" + SINALIZADOR);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArvoreGen_2.Server.DbConnections;
using Microsoft.EntityFrameworkCore;

namespace ArvoreGen_2.Server.Models
{
    public class RelacionamentoService : IRelacionamentoService
    {
        private readonly ApplicationDbContext _context;

        const string SINALIZADOR = " #############################";

        public RelacionamentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        /* Visualizar ------------------------- */
        public async Task<List<Relacionamento>> GetAll()
        {
            return await _context.Relacionamentos.ToListAsync();
        }

        /* Adicionar ------------------------- */
        public async Task Adicionar(Relacionamento relacionamento)
        {
            
            _context.Relacionamentos.Add(relacionamento);

            Console.WriteLine("Data Falecimento: " + SINALIZADOR);
            
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deletar(int id)
        {
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

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArvoreGen_2.Server.DbConnections;
using Microsoft.EntityFrameworkCore;

namespace ArvoreGen_2.Server.Models
{
    public class PessoaService : IPessoaService
    {
        private readonly ApplicationDbContext _context;

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> CriarPessoaAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa; // Retorna a pessoa criada
        }

        public async Task<IEnumerable<Pessoa>> ObterTodasPessoasAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> ObterPessoaPorIdAsync(int id)
        {
            return await _context.Pessoas
                                 .Where(p => p.IdPessoa == id)
                                 .FirstOrDefaultAsync();
        }

        public async Task<bool> AtualizarPessoaAsync(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<bool> RemoverPessoaAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return false;
            }

            _context.Pessoas.Remove(pessoa);
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }

}
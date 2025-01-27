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

        const string SINALIZADOR = " #############################";

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        /* Visualizar ------------------------- */
        public async Task<List<Pessoa>> GetAll()
        {
            return await _context.Pessoas.ToListAsync();
        }

        /* Adicionar ------------------------- */
        public async Task Adicionar(Pessoa pessoa)
        {
            pessoa.DataNascimento = pessoa.DataNascimento?.ToUniversalTime();
            
            _context.Pessoas.Add(pessoa);

            Console.WriteLine("Data Falecimento: " + pessoa.DataNascimento + SINALIZADOR);
            
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return false;
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<bool> Editar(int id, Pessoa pessoa)
        {
            var pessoaExistente = await _context.Pessoas.FindAsync(id);
            if (pessoaExistente == null)
            {
                return false;
            }

            pessoaExistente.Nome = pessoa.Nome;
            pessoaExistente.Sexo = pessoa.Sexo;
            pessoaExistente.DataNascimento = pessoa.DataNascimento;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
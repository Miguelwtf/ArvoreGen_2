using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ArvoreGen_2.Server.DbConnections;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace ArvoreGen_2.Server.Models
{
    public class PessoaService : IPessoaService
    {
        private readonly ApplicationDbContext _context;

        const string SINALIZADOR = " ##########################################################";

        public PessoaService(ApplicationDbContext context)
        {
            _context = context;
        }

        /* Visualizar ------------------------- */
        public async Task<List<Pessoa>> GetAll()
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - GetAll" + "\n" + SINALIZADOR);

            return await _context.Pessoas.ToListAsync();
        }

        /* Adicionar ------------------------- */
        public async Task Adicionar(Pessoa pessoa)
        {
            pessoa.DataNascimento = pessoa.DataNascimento?.ToUniversalTime();
            
            _context.Pessoas.Add(pessoa);

            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Adicionar" + "\n" + SINALIZADOR);

            await _context.SaveChangesAsync();
        }
        
        /* Deletar ------------------------- */
        public async Task<bool> Deletar(int id)
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Deletar" + "\n" + SINALIZADOR);

            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return false;
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true; 
        }

        /* Editar ------------------------- */
        public async Task<bool> Editar(int id, Pessoa pessoa)
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - Editar" + "\n" + SINALIZADOR);

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

        public async Task<List<Pessoa>> ListarPessoa()
        {
            Console.WriteLine(SINALIZADOR + "\n" + DateTime.Now + $" - {this.GetType().Name}" + $" - ListarPessoa" + "\n" + SINALIZADOR);

            return await _context.Pessoas.Select(p => new Pessoa { IdPessoa = p.IdPessoa, Nome = p.Nome }).ToListAsync();
        }
    }
}
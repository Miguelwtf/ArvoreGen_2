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

        public async Task<List<Pessoa>> GetAll()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task Adicionar(Pessoa pessoa)
        {
            pessoa.datafalecimento = pessoa.datafalecimento?.ToUniversalTime();
            pessoa.datanascimento = pessoa.datanascimento?.ToUniversalTime();
            
            _context.Pessoas.Add(pessoa);

            Console.WriteLine("Data Criação: " + pessoa.datacriacao + SINALIZADOR);
            Console.WriteLine("Data Nascimento: " + pessoa.datanascimento + SINALIZADOR);
            Console.WriteLine("Data Falecimento: " + pessoa.datafalecimento + SINALIZADOR);
            
            await _context.SaveChangesAsync();
        }
    }
}
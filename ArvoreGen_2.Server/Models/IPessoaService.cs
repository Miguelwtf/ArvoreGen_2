using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Models;

namespace ArvoreGen_2.Server.Models
{

    public interface IPessoaService
    {
        Task<Pessoa> CriarPessoaAsync(Pessoa pessoa);

        Task<IEnumerable<Pessoa>> ObterTodasPessoasAsync();

        Task<Pessoa> ObterPessoaPorIdAsync(int id);

        Task<bool> AtualizarPessoaAsync(Pessoa pessoa);

        Task<bool> RemoverPessoaAsync(int id);
    }
}

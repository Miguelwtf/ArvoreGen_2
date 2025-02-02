using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArvoreGen_2.Server.Models
{

    public interface IPessoaService
    {
        Task<List<Pessoa>> GetAll();
        
        Task Adicionar(Pessoa pessoa);

        Task<bool> Deletar(int id);

        Task<bool> Editar(int id, Pessoa pessoa);

        Task<List<Pessoa>> ListarPessoa();
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArvoreGen_2.Server.DbConnections;
using ArvoreGen_2.Server.Dtos;
using ArvoreGen_2.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArvoreGen_2.Server.Models
{

    public interface IRelacionamentoService
    {
        Task<List<RelacionamentoDto>> GetAll();

        Task Adicionar(Relacionamento relacionamento);

        Task<bool> Deletar(int id);

        Task<bool> Editar(int id, Relacionamento relacionamento);
    }
}

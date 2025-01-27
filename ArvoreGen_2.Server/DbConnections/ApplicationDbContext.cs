using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ArvoreGen_2.Server.Models;

namespace ArvoreGen_2.Server.DbConnections
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Relacionamento> Relacionamentos { get; set; }
    }
}

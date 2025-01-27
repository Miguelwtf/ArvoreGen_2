using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArvoreGen_2.Server.Models;

namespace ArvoreGen_2.Server.Models
{
    [Table("relacionamentos")]
    public class Relacionamento
    {
        [Key]
        public int IdRelacionamento { get; set; }

        [Required]
        public int? IdPessoa1 { get; set; }

        [Required]
        public int? IdPessoa2 { get; set; }

        [StringLength(100)]
        public string? TipoRelacionamento { get; set; } 
    }
}
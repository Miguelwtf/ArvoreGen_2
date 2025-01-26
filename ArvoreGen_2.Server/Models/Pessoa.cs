using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArvoreGen_2.Server.Models;

namespace ArvoreGen_2.Server.Models
{
    [Table("pessoas")]
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nome { get; set; } 

        public DateTime? DataNascimento { get; set; }

        [StringLength(10)]
        public string? Sexo { get; set; } 
    }
}
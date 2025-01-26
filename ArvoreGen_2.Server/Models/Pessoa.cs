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
        public int idpessoa { get; set; }

        [Required]
        [StringLength(100)]
        public string? nomesolteiro { get; set; } 

        public DateTime? datanascimento { get; set; }

        public DateTime? datafalecimento { get; set; }

        [StringLength(1)]
        public string? sexo { get; set; } 

        [StringLength(100)]
        public string? localnascimento { get; set; } 

        [StringLength(100)]
        public string? localfalecimento { get; set; }

        public DateTime datacriacao { get; set; } 

        [StringLength(100)]
        public string? nomecasado { get; set; } 

        [StringLength(100)]
        public string? nomealternativo1 { get; set; } 

        [StringLength(100)]
        public string? nomealternativo2 { get; set; } 

        [StringLength(250)]
        public string? observacao { get; set; } 
    }

}
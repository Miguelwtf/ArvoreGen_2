using System;
using System.ComponentModel.DataAnnotations;
using ArvoreGen_2.Server.Models;

namespace ArvoreGen_2.Server.Models
{

    public class Pessoa
    {
        public int IdPessoa { get; set; }

        [Required]
        [StringLength(100)]
        public string? NomeSolteiro { get; set; } 

        public DateTime? DataNascimento { get; set; }

        public DateTime? DataFalecimento { get; set; }

        [StringLength(1)]
        [RegularExpression("^[MF]$", ErrorMessage = "Sexo deve ser 'M' ou 'F'.")]
        public string? Sexo { get; set; } 

        [StringLength(100)]
        public string? LocalNascimento { get; set; } 

        [StringLength(100)]
        public string? LocalFalecimento { get; set; }

        public DateTime DataCriacao { get; set; } 

        [StringLength(100)]
        public string? NomeCasado { get; set; } 

        [StringLength(100)]
        public string? NomeAlternativo1 { get; set; } 

        [StringLength(100)]
        public string? NomeAlternativo2 { get; set; } 

        [StringLength(250)]
        public string? Observacao { get; set; } 
    }

}
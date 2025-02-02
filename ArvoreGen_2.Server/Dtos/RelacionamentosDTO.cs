
namespace ArvoreGen_2.Server.Dtos
{
    public class RelacionamentoDto
    {
        public int IdRelacionamento { get; set; }
        public string Pessoa1Nome { get; set; }  // Nome da primeira pessoa
        public string Pessoa2Nome { get; set; }  // Nome da segunda pessoa
        public string TipoRelacionamento { get; set; }
    }
}
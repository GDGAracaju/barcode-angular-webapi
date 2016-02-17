using System.ComponentModel.DataAnnotations;

namespace WebApi.Core.Domain.Biblioteca
{
    public class Pessoa 
    {
        public int PessoaId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public virtual Conta Conta { get; set; }
    }


}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Core.Domain.Biblioteca
{
    public class Conta
    {
        [Key, Required]
        public string Login { get; set; }

        [Required]
        public string Senha {get; set;}

        public virtual ICollection<RegistroDeEmprestimo> Reservas { get; set; }

        public virtual ICollection<RegistroDeEmprestimo> Emprestimos { get; set; }

        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
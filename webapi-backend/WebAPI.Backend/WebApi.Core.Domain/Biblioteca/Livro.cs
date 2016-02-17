using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Domain.Biblioteca
{
    public class Livro
    {
        [Key, Required]
        public string ISBN { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public string Resumo { get; set; }

        [Required]
        [StringLength(100)]
        public string editora { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataDePublicacao { get; set; }

        public virtual ICollection<Autor> Autores { get; set; }

        public virtual ICollection<RegistroDeEmprestimo> RegistrosDeEmprestimo {get; set;}
     }
}

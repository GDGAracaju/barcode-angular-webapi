using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Core.Domain.Biblioteca
{
    public class Autor
    {
        public int AutorId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataDeNascimento { get; set; }

        public virtual ICollection<Livro> LivrosEscritos { get; set; }

    }
}
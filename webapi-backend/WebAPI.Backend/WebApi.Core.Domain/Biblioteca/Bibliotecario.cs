using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.Domain.Biblioteca
{
    public class Bibliotecario
    {
        public int BibliotecarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public IPesquisa PesquisarNoCatalogo { get; set; }

        public IGerenciamento GerenciadorDeCatalogo { get; set; }
    }
}

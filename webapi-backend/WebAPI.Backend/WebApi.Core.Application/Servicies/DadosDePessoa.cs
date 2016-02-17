using System.ComponentModel.DataAnnotations;
using WebApi.Core.Domain.Biblioteca;

namespace WebApi.Core.Application.Servicies
{
    public class DadosDePessoa
    {
        [Required]
        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }
        
        [Required]
        public string ConfirmacaoDeSenha { get; set; }

        public virtual Pessoa EmPessoa()
        {
            return new Pessoa
            {
                Nome = Nome,
                Endereco = Endereco,
                Conta = new Conta
                {
                    Login = Login,
                    Senha = Senha
                }
            };
        }
    }

    public class DadosAtualizadosDePessoa : DadosDePessoa
    {
        public int PessoaId { get; set; }

        public override Pessoa EmPessoa()
        {
            var pessoa = base.EmPessoa();
            PessoaId = pessoa.PessoaId;
            return pessoa;
        }
    }
}
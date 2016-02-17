using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Domain.Biblioteca;
using WebApi.Infraestructure.Repositories;

namespace WebApi.Core.Application.Servicies
{
    public interface IServicoDePessoas
    {
        IList<PessoaDto> ListarPessoas();

        void Cadastrar(DadosDePessoa pessoa);

        void Atualizar(DadosAtualizadosDePessoa pessoa);

        void RemoverPor(int pessoaId);

        PessoaDto PessoaPor(int id);
    }

    public class ServicoDePessoas : IServicoDePessoas
    {
        private readonly IRepository<Pessoa> _repositorio;
        private readonly IRepository<Conta> _repositorioDeContas;

        public ServicoDePessoas(IRepository<Pessoa> repositorioDePessoas,
            IRepository<Conta> repositorioDeContas)
        {
            _repositorio = repositorioDePessoas;
            _repositorioDeContas = repositorioDeContas;
        }

        public async void Atualizar(DadosAtualizadosDePessoa dados)
        {
            await _repositorio.Update(dados.EmPessoa());
        }

        public  void Cadastrar(DadosDePessoa dados)
        {
           var x =  _repositorio.Insert(dados.EmPessoa());
        }

        public IList<PessoaDto> ListarPessoas()
        {
            return _repositorio.QueryAll().Select(p => new PessoaDto
            {
                PessoaId = p.PessoaId,
                Endereco = p.Endereco,
                Nome = p.Nome
            }).ToList();
        }

        public PessoaDto PessoaPor(int id)
        {
            return _repositorio.QueryAll().First(x => x.PessoaId == id).EmPessoaDto();
        }

        public void RemoverPor(int pessoaId)
        {
            var p = _repositorio.QueryAll().First(x => x.PessoaId == pessoaId);
             _repositorioDeContas.Delete(p.Conta);
             _repositorio.Delete(p);
             _repositorio.SaveChanges();
        }

    }

    public static class EmPessoaDtoEx
    {
        public static PessoaDto EmPessoaDto(this Pessoa pessoa)
        {
            return new PessoaDto
            {
                PessoaId = pessoa.PessoaId,
                Nome = pessoa.Nome,
                Endereco = pessoa.Endereco
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Domain.Biblioteca;

namespace WebApi.Infraestructure
{
    public class BibliotecaDbContext: DbContext
    {

        public IDbSet<Autor> Autores { get; set; }
        public IDbSet<Bibliotecario> Bibliotecarios { get; set; }
        public IDbSet<Conta> Conta { get; set; }
        public IDbSet<Livro> Livros { get; set; }
        public IDbSet<Pessoa> Pessoas { get; set; }
        public IDbSet<RegistroDeEmprestimo> Registros { get; set; }

        public BibliotecaDbContext() : base("biblioteca") {
            Database.SetInitializer<BibliotecaDbContext>(new CreateDatabaseIfNotExists<BibliotecaDbContext>());

            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Pessoa>().HasKey(p => p.PessoaId).HasRequired(p => p.Conta).WithRequiredPrincipal(c => c.Pessoa);
        }
    }
}

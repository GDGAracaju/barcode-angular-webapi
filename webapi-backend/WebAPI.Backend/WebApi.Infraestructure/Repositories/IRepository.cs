using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Infraestructure.Repositories
{
    public interface IRepository<TEntity>
    {

        /// <summary>
        /// Insere uma entidade
        /// </summary>
        /// <param name="entity">Uma nova entidade</param>
        int Insert(TEntity entity);

        /// <summary>
        /// Atualiza a entidade
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        Task<int> Update(TEntity entity);

        /// <summary>
        /// Deleta a entidade
        /// </summary>
        /// <param name="entity">Entidade a ser deletada</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Expõe uma interface que permite executar operações de pesquisa.
        /// </summary>
        /// <returns>Um objeto de pesquisa</returns>
        IQueryable<TEntity> QueryAll();

        int SaveChanges();
    }
}

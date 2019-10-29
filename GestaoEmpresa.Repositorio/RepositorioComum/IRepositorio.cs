using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresa.Repositorio.RepositorioComum
{
    public interface IRepositorio<TEntidade>
    {
        List<TEntidade> SelectAll(params string[] props);
        List<TEntidade> SelectAll(Expression<Func<TEntidade, bool>> predicate, params string[] props);
        /// <summary>
        /// Seleciona todos os registros da entidade
        /// </summary>
        /// <param name="props">Nome das propriedades de navegação a ser incluido</param>
        /// <returns></returns>
        IQueryable<TEntidade> SelectAllQuery(params string[] props);
        IQueryable<TEntidade> SelectAllQuery(Expression<Func<TEntidade, bool>> predicate, params string[] props);
        TEntidade SelectById(int? id);
        void Delete(TEntidade entidade);
        void Delete(List<TEntidade> entidades);
        void Delete(int? id);
        void Insert(TEntidade entidade);
        void Update(TEntidade entidade);
        Task<List<TEntidade>> SelectAllAsync(params string[] props);
        Task<List<TEntidade>> SelectAllAsync(Expression<Func<TEntidade, bool>> predicate, params string[] props);
        Task<TEntidade> SelectByIdAsync(int? id);
        Task<int> DeleteAsync(TEntidade entidade);
        Task<int> DeleteAsync(List<TEntidade> entidades);
        Task<int> DeleteAsync(int? id);
        Task InsertAsync(TEntidade entidade);
        Task UpdateAsync(TEntidade entidade);
        Task<IQueryable<TEntidade>> SelectAllQueryAsync(params string[] props);
        Task<IQueryable<TEntidade>> SelectAllQueryAsync(Expression<Func<TEntidade, bool>> predicate, params string[] props);
    }
}

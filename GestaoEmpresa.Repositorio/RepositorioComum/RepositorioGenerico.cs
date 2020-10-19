using GestaoEmpresa.Repositorio.RepositorioExtension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestaoEmpresa.Repositorio.RepositorioComum
{
    public class RepositorioGenerico<TEntidade> : IRepositorio<TEntidade> where TEntidade : class
    {
        protected DbContext dbContext;
        public RepositorioGenerico(DbContext context)
        {
            dbContext = context;
        }
        public virtual void Delete(TEntidade entidade)
        {
            try
            {

                dbContext.Set<TEntidade>().Remove(entidade);
                dbContext.SaveChanges();

            }
            catch (Exception)
            {
                try
                {


                    dbContext.Set<TEntidade>().Attach(entidade);
                    dbContext.Entry(entidade).State = EntityState.Deleted;
                    dbContext.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw new Exception($"{ex.Message}", ex);
                }


            }
        }

        public virtual void Delete(List<TEntidade> entidades)
        {

            try
            {
                dbContext.Set<TEntidade>().RemoveRange(entidades);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(int? id)
        {
            if (id == null) throw new Exception("Id não pode ter valor nulo");
            TEntidade lEntidade = dbContext.Set<TEntidade>().Find(id.Value);
            Delete(lEntidade);
        }

        public virtual Task<int> DeleteAsync(TEntidade entidade)
        {
            try
            {
                dbContext.Set<TEntidade>().Remove(entidade);
                return dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual Task<int> DeleteAsync(List<TEntidade> entidades)
        {
            try
            {
                dbContext.Set<TEntidade>().RemoveRange(entidades);
                return dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual Task<int> DeleteAsync(int? id)
        {
            if (id == null) throw new Exception("Id não pode ter valor nulo");
            TEntidade lEntidade = dbContext.Set<TEntidade>().Find(id.Value);
            return DeleteAsync(lEntidade);
        }

        public virtual void Insert(TEntidade entidade)
        {
            try
            {
                dbContext.Set<TEntidade>().Add(entidade);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual Task InsertAsync(TEntidade entidade)
        {
            try
            {
                dbContext.Set<TEntidade>().Add(entidade);
                return dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<TEntidade> SelectAll(params string[] props)
        {
            var query = dbContext.Set<TEntidade>().DynamicInclude(props);
            return query.ToList();
        }

        public virtual List<TEntidade> SelectAll(Expression<Func<TEntidade, bool>> predicate, params string[] props)
        {
            var query = dbContext.Set<TEntidade>().DynamicInclude(props);
            return query.Where(predicate).ToList();
        }

        public virtual Task<List<TEntidade>> SelectAllAsync(params string[] props)
        {
            var query = dbContext.Set<TEntidade>().DynamicInclude(props);
            return query.ToListAsync();
        }

        public virtual Task<List<TEntidade>> SelectAllAsync(Expression<Func<TEntidade, bool>> predicate, params string[] props)
        {
            var entidades = Task.Run(() =>
            {
                return SelectAll(predicate, props);
            });
            return entidades;
        }

        public virtual IQueryable<TEntidade> SelectAllQuery(params string[] props)
        {
            var query = dbContext.Set<TEntidade>().DynamicInclude(props);
            return query;
        }

        public virtual IQueryable<TEntidade> SelectAllQuery(Expression<Func<TEntidade, bool>> predicate, params string[] props)
        {
            var query = dbContext.Set<TEntidade>().DynamicInclude(props);
            return query.Where(predicate);
        }

        public virtual Task<IQueryable<TEntidade>> SelectAllQueryAsync(params string[] props)
        {
            var entidades = Task.Run(() =>
            {
                return SelectAllQuery(props);
            });
            return entidades;
        }

        public virtual Task<IQueryable<TEntidade>> SelectAllQueryAsync(Expression<Func<TEntidade, bool>> predicate, params string[] props)
        {
            var entidades = Task.Run(() =>
            {
                return SelectAllQuery(predicate, props);
            });
            return entidades;
        }

        public virtual TEntidade SelectById(int? id)
        {
            return dbContext.Set<TEntidade>().Find(id.Value);
        }

        public virtual Task<TEntidade> SelectByIdAsync(int? id)
        {
            if (!id.HasValue) return null;
            return dbContext.Set<TEntidade>().FindAsync(id.Value).AsTask();
        }

        public virtual void Update(TEntidade entidade)
        {
            try
            {
                dbContext.Set<TEntidade>().Attach(entidade);
                dbContext.Entry(entidade).State = EntityState.Modified;
                dbContext.SaveChanges();

            }
            catch (Exception ex1)
            {
                try
                {
                    dbContext.Set<TEntidade>().Update(entidade);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception($"{ex.Message}", ex);
                }
            }
        }

        public virtual Task UpdateAsync(TEntidade entidade)
        {
            dbContext.Update(entidade);
            return dbContext.SaveChangesAsync();
        }
    }
}

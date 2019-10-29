using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoEmpresa.Repositorio.RepositorioExtension
{
    public static class DbSetExtensio
    {
        public static IQueryable<T> DynamicInclude<T>(this DbSet<T> dbSet, params string[] props) where T : class
        {
            var propriedades = typeof(T).GetProperties();
            var query = dbSet.AsQueryable();
            for (int i = 0; i < props.Length; i++)
            {
                if (propriedades.Any(x => x.Name == props[i]))
                    query = query.Include(props[i]);
            }
            return query;
        }
    }
}

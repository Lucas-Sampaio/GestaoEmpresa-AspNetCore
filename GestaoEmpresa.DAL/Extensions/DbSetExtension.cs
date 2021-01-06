using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestaoEmpresa.DAL.Extensions
{
    public static class DbSetExtension
    {
        public static IQueryable<T> DynamicInclude<T>(this DbSet<T> dbSet, params string[] props) where T : class
        {
            var propriedades = typeof(T).GetProperties();
            var query = dbSet.AsNoTracking();
            for (int i = 0; i < props.Length; i++)
            {
                if (propriedades.Any(x => x.Name == props[i]))
                    query = query.Include(props[i]);
            }
            return query;
        }
    }
}

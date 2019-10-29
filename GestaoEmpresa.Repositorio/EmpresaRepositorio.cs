using GestaoEmpresa.Dominio;
using GestaoEmpresa.Repositorio.RepositorioComum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresa.Repositorio
{
    public class EmpresaRepositorio : RepositorioGenerico<Empresa>
    {
        public EmpresaRepositorio(DbContext context) : base(context)
        {
        }
        public override Task<Empresa> SelectByIdAsync(int? id)
        {
            return dbContext.Set<Empresa>().Include(x => x.Endereco).Include(x => x.Funcionarios).SingleOrDefaultAsync(x => x.Id == id.GetValueOrDefault());
        }

    }
}

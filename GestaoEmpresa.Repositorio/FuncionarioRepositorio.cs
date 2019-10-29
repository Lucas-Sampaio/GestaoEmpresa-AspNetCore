using GestaoEmpresa.Dominio;
using GestaoEmpresa.Repositorio.RepositorioComum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresa.Repositorio
{
    public class FuncionarioRepositorio : RepositorioGenerico<Funcionario>
    {
        public FuncionarioRepositorio(DbContext context) : base(context)
        {
        }
        public override Task<Funcionario> SelectByIdAsync(int? id)
        {
            return dbContext.Set<Funcionario>().Include(x => x.Endereco).Include(x => x.Jornadas).SingleOrDefaultAsync(x => x.Id == id.GetValueOrDefault());
        }

    }
}

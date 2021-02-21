using GestaoEmpresa.DAL.Extensions;
using GestaoEmpresa.Dominio;
using GestaoEmpresa.Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.DAL.Repositorio
{
    public class EmpresaRepositorio : IEmpresaRepository
    {
        private readonly GestaoContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public EmpresaRepositorio(GestaoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Empresa>> ObterTodos(params string[] props)
        {
            return await _context.Empresas.DynamicInclude(props).ToListAsync();
        }

        public async Task<Empresa> ObterPorId(int id, params string[] props)
        {
            return await _context.Empresas.DynamicInclude(props).SingleOrDefaultAsync(x => x.Id == id);
        }
        public void Adicionar(Empresa entidade)
        {
            _context.Empresas.Add(entidade);
        }

        public void Atualizar(Empresa entidade)
        {
            _context.Empresas.Update(entidade);
        }
        public void Remover(int id)
        {
            var entity = _context.Empresas.Find(id);
            _context.Empresas.Remove(entity);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            throw new System.NotImplementedException();
        }
    }
}

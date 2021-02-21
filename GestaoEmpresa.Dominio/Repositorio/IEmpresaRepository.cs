using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.Dominio.Repositorio
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<IEnumerable<Empresa>> ObterTodos(params string[] props);
        Task<Empresa> ObterPorId(int id, params string[] props);
        void Adicionar(Empresa entidade);
        void Atualizar(Empresa entidade);
        void Remover(int id);
        void AdicionarEndereco(Endereco endereco);
    }
}

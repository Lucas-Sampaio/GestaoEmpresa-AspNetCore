using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.Dominio.Repositorio
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<IEnumerable<Funcionario>> ObterTodos(params string[] props);
        Task<Empresa> ObterPorId(int id, params string[] props);
        void Adicionar(Funcionario entidade);
        void Atualizar(Funcionario entidade);
        void Remover(int id);
        void AdicionarJornada(JornadaTrabalho jornada);
        void RemoverJornada(int IdJornada);
        void AdicionarEndereco(Endereco endereco);
    }
}

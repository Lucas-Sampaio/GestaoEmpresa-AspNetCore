using GestaoEmpresa.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Services
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioVM>> ObterTodos();
        Task<FuncionarioVM> ObterPorId(int id);
        Task<ResponseResult> CadastrarFuncionario(FuncionarioVM FuncionarioVM);
        Task<ResponseResult> AtualizarFuncionario(int id, FuncionarioVM FuncionarioVM);
        Task<ResponseResult> RemoverFuncionario(int id);
        Task<ResponseResult> AdicionarJornada(JornadaTrabalhoVMVAL jornada);
        Task<ResponseResult> RemoverJornada(int id, int jornadaId);

    }
}

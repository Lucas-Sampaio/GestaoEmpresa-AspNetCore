using GestaoEmpresa.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Services
{
    public interface IEmpresaService
    {
        Task<IEnumerable<EmpresaVM>> ObterTodos();
        Task<EmpresaVM> ObterPorId(int id);
        Task<ResponseResult> CadastrarEmpresa(EmpresaVM empresaVMVal);
        Task<ResponseResult> AtualizarEmpresa(int id, EmpresaVM empresaVMVal);
        Task<ResponseResult> RemoverEmpresa(int id);
    }
}

using GestaoEmpresa.DominioViewModel.EmpresaViewModel;
using GestaoEmpresa.Extensions.ConexaoApi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoEmpresa.Web.Services
{
    public interface IEmpresaService
    {
        Task<ResponseApi<IEnumerable<EmpresaVM>>> ObterTodos();
        Task<ResponseApi<EmpresaVM>> ObterPorId(int id);
        Task<ResponseApi<bool>> CadastrarEmpresa(EmpresaVMVal empresaVMVal);
        Task<ResponseApi<bool>> AtualizarEmpresa(int id,EmpresaVM empresaVMVal);
        Task<ResponseApi<bool>> RemoverEmpresa(int id);
    }
}

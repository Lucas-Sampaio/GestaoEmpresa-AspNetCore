using System.Threading.Tasks;

namespace GestaoEmpresa.DAL
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

using System.Threading.Tasks;

namespace GestaoEmpresa.Dominio
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}

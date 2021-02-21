using System;

namespace GestaoEmpresa.Dominio.Repositorio
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

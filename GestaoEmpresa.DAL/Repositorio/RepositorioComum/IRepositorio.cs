using GestaoEmpresa.Dominio;
using System;

namespace GestaoEmpresa.DAL.Repositorio.RepositorioComum
{
    public interface IRepositorio<TEntidade> : IDisposable where TEntidade : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}

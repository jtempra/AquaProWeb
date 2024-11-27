using AquaProWeb.Domain.Contracts;

namespace AquaProWeb.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IWriteRepositoryAsync<T> WriteRepositoryFor<T>() where T : BaseEntity;
        IReadRepositoryAsync<T> ReadRepositoryFor<T>() where T : BaseEntity;
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}

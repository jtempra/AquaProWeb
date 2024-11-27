using AquaProWeb.Application.Repositories;
using AquaProWeb.Domain.Contracts;
using AquaProWeb.Infrastructure.Contexts;
using System.Collections;

namespace AquaProWeb.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private bool _disposed;
        private Hashtable _repositories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public IReadRepositoryAsync<T> ReadRepositoryFor<T>() where T : BaseEntity
        {
            if (_repositories is null)
            {
                _repositories = new Hashtable();
            }

            var type = $"{typeof(T).Name}_Read";

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(ReadRepositoryAsync<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IReadRepositoryAsync<T>)_repositories[type];
        }

        public IWriteRepositoryAsync<T> WriteRepositoryFor<T>() where T : BaseEntity
        {
            if (_repositories is null)
            {
                _repositories = new Hashtable();
            }

            var type = $"{typeof(T).Name}_Write";

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(WriteRepositoryAsync<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IWriteRepositoryAsync<T>)_repositories[type];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}

using AquaProWeb.Application.Repositories;
using AquaProWeb.Domain.Contracts;
using AquaProWeb.Infrastructure.Contexts;

namespace AquaProWeb.Infrastructure.Repositories
{
    public class WriteRepositoryAsync<T> : IWriteRepositoryAsync<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public WriteRepositoryAsync(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            T entityInDb = await _context.Set<T>().FindAsync(entity.Id);
            _context.Entry(entityInDb).CurrentValues.SetValues(entity);
            return entity;
        }
    }
}

using System.Linq.Expressions;

namespace AquaProWeb.Application.Repositories
{
    public interface IReadRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(int Id, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetByTextAsync(string searchTerm);
        List<T> GetByPredicateAsync(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}

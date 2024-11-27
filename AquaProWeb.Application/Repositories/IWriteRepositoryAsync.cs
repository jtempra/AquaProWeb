namespace AquaProWeb.Application.Repositories
{
    public interface IWriteRepositoryAsync<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}

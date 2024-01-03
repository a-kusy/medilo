namespace Medilo.API.Repositories.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task AddRangeAsync(IEnumerable<T> entities);
    }
}

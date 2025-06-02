namespace Amazon.Api.Core.Interfaces
{
    public interface IGenericService<T> : IDisposable where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(long entityId);
        IQueryable<T> GetAll();
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteAsync(long id);
    }
}

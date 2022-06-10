using CityManage.DAL;

namespace CityManage.Interfaces;

public interface IRepository<T> where T : DbEntity, new()
{
    Task<List<T>> GetAsync();
    Task<Guid> CreateAsync(T entity);
    Task<Guid> UpdateAsync(T entity);
    Task<Guid> DeleteAsync(Guid id);
}
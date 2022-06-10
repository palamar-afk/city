using CityManage.DAL;
using CityManage.Exceptions;
using CityManage.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CityManage.Services;

public class Repository<T> : IRepository<T> where T : DbEntity, new()
{
    private readonly CityDbContext _context;
    
    public Repository(CityDbContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAsync()
    {
        var result = await _context.Set<T>().ToListAsync();
        if (!result.Any())
            throw new NotFoundException();

        return result;
    }

    public async Task<Guid> CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Guid> UpdateAsync(T entity)
    {
        var existingEntity = await _context
            .Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (existingEntity == null)
            throw new NotFoundException();

        entity.Id = existingEntity.Id;
        _context.Set<T>().Update(entity);
        
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        var entity = new T {
            Id = id
        };
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}
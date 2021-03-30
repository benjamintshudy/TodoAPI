using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Models;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly TodoContext _context;
    private DbSet<T> entities;

    public Repository(TodoContext context)
    {
        _context = context;
        entities = _context.Set<T>();
    }

    public async Task<List<T>> All()
    {
        return await entities.ToListAsync();
    }

    public async Task<T> Get(long id)
    {
        return await entities.FindAsync(id);
    }

    public async Task<T> Create(T entity)
    {
        entities.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task Update(long id, T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Delete(long id)
    {
        var entity = await entities.FindAsync(id);

        if (entity == null)
        {
            return false;
        }

        entities.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
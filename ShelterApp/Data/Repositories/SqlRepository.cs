using Microsoft.EntityFrameworkCore;
using ShelterApp.Data.Entities;

namespace ShelterApp.Data.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;

    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T employee)
    {
        _dbSet.Add(employee);
    }

    public void Remove(T employee)
    {
        _dbSet.Remove(employee);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }

    
}

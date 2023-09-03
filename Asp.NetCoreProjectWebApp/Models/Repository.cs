using System.Linq.Expressions;
using Asp.NetCoreProjectWebApp.Utility;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCoreProjectWebApp.Models;

public class Repository<T> : IRepository<T> where T :  class
{
    private readonly UygulamaDbContext _uygulamaDbContext;
    internal DbSet<T> dbSet;

    public Repository(UygulamaDbContext uygulamaDbContext)
    {
        _uygulamaDbContext = uygulamaDbContext;
         dbSet = _uygulamaDbContext.Set<T>();
    }
    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = dbSet;
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filtre)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filtre);
        return query.FirstOrDefault();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void DeleteInterval(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}
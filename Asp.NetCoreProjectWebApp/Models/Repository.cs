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
         this.dbSet = _uygulamaDbContext.Set<T>();
        _uygulamaDbContext.Kitaplar.Include(k => k.KitapTuru);
    }
    public IEnumerable<T> GetAll(string? includeProps=null)
    {
        IQueryable<T> query = dbSet;
         if (!string.IsNullOrEmpty(includeProps))
        {
            foreach (var prop in includeProps.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries)) {
                query =query.Include(prop);
            }
        }
        return query.ToList();
    }

    public T Get(Expression<Func<T, bool>> filtre, string? includeProps = null)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filtre);
        if (!string.IsNullOrEmpty(includeProps))
        {
            foreach (var prop in includeProps.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries)) {
                query =query.Include(prop);
            }
        }
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
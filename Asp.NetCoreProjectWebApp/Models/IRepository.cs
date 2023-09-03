using System.Linq.Expressions;

namespace Asp.NetCoreProjectWebApp.Models;

public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll();
    T Get(Expression<Func<T, bool>> filtre);
    void Add(T entity);
    void Remove(T entity);
    void DeleteInterval(IEnumerable<T> entity);

}
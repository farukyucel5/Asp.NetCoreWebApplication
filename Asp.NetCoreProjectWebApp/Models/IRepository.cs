using System.Linq.Expressions;

namespace Asp.NetCoreProjectWebApp.Models;

public interface IRepository<T> where T: class
{
    IEnumerable<T> GetAll(string? includeProps = null);
    T Get(Expression<Func<T, bool>> filtre, string? includeProps = null);
    void Add(T entity);
    void Remove(T entity);
    void DeleteInterval(IEnumerable<T> entity);

}
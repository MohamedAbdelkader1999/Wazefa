using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Data
{
    public interface IRepository<T, Key> where T : class
    {
        T Add(T entity);
        void Add(List<T> entities);
        Task<T> AddAsync(T entity);
        Task AddAsync(List<T> entities);
        T? GetById(Key id);
        Task<T?> GetByIdAsync(Key id);
        IQueryable<T> GetList(Expression<Func<T, bool>> expression);
        T Update(T entity);
        void Update(List<T> entities);
        void Delete(T entity);
        void Delete(List<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression);
        T? SingleOrDefault(Expression<Func<T, bool>> expression);
        IQueryable<T> GetPaged(Expression<Func<T, bool>> expression, int pageSize = 10, int pageIndex = 0, int skip = 0, string orderBy = "Id", bool IsAscending = true, params string[] includes);
    }
}

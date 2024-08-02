using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wazefa.Core.Interfaces
{
    public interface IRepository<T, Key> where T : class
    {
        T Add(T entity);
        void Add(List<T> entities);
        Task<T> AddAsync(T entity);
        Task AddAsync(List<T> entities);
        T? GetById(Key id);
        Task<T?> GetByIdAsync(Key id);
        IQueryable<T> GetList(Func<T, bool> where);
        T Update(T entity);
        void Update(List<T> entities);
        void Delete(T entity);
        void Delete(List<T> entities);
        Task<bool> AnyAsync(Func<T, bool> where);
        bool Any(Func<T, bool> where);
        Task<T?> SingleOrDefaultAsync(Func<T, bool> where);
        T? SingleOrDefault(Func<T, bool> where);
        IQueryable<T> GetPaged(Func<T, bool> where, int pageSize = 10, int pageIndex = 0, int skip = 0, string orderBy = "Id", bool IsAscending = true, params string[] includes);
    }
}

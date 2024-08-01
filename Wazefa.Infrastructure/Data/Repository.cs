using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wazefa.Core.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Wazefa.Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WazefaContext _dbContext;
        private readonly DbSet<T> set;

        public Repository(WazefaContext dbContext)
        {
            _dbContext = dbContext;
            set = _dbContext.Set<T>();
        }
        public IQueryable<T> GetPaged(Func<T,bool> where , int pageSize = 10 ,  int pageIndex = 0,int skip = 0,SortOrder sortBy = SortOrder.Ascending,params string[] includes)
        {
            Expression<Func<T, bool>> expression = (a) => where(a);
            var query = set.AsQueryable();
            if (includes != null && includes.Length > 0)
                foreach (string i in includes)
                    query = query.Include(i);
            int rows = query.Count();
            if (pageIndex <= 0)
                pageIndex = 1;
            if (rows < pageSize)
                pageIndex = 1;
            int rowscount = (pageIndex - 1) * pageSize;
            return query.Where(expression).Skip(skip).Take(pageSize);
        }
        public T Add(T entity)
        {
            EntityEntry<T> resultEntity = set.Add(entity);
            return resultEntity.Entity;
        }
        public void Add(List<T> entities) =>
            set.AddRange(entities);
        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> resultEntity = await set.AddAsync(entity);
            return resultEntity.Entity;
        }
        public async Task AddAsync(List<T> entities) =>
            await set.AddRangeAsync(entities);
        public void Delete(T entity) =>
            set.Remove(entity);
        public void Delete(List<T> entities) =>
            set.RemoveRange(entities);

        public T? GetById(int id) => set.Find(id);

        public async Task<T?> GetByIdAsync(int id) 
            => await set.FindAsync(id);
        public IQueryable<T> GetList(Func<T, bool> where)
        {
            Expression<Func<T, bool>> expression = (a) => where(a);
            return set.Where(expression);
        }
        public T Update(T entity)
        {
            EntityEntry<T> resultEntity = set.Update(entity);
            return resultEntity.Entity;
        }

        public void Update(List<T> entities) =>
             set.UpdateRange(entities);
        public bool Any(Func<T, bool> where)
        {
            Expression<Func<T, bool>> expression = (a) => where(a);
            return set.Any(expression);
        }
        public async Task<bool> AnyAsync(Func<T, bool> where)
        {
            Expression<Func<T, bool>> expression = (a) => where(a);
            return await set.AnyAsync(expression);
        }

        public async Task<T?> SingleOrDefaultAsync(Func<T, bool> where) 
        {
            Expression<Func<T, bool>> expression = (a) => where(a);
            return await set.SingleOrDefaultAsync(expression);

        }
        public T? SingleOrDefault(Func<T, bool> where)
        {
            Expression<Func<T, bool>> expression = (a) => where(a);
            return set.SingleOrDefault(expression);
        }

    }
}

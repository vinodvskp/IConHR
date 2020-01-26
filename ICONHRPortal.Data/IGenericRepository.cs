using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(long id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
        IQueryable<TEntity> GetQueryWithInclude(TEntity entity, string toInclude);
        IQueryable<TEntity> GetQueryWithMultipleInclude(string[] includes);
    }
}

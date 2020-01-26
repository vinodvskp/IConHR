using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.Models;

namespace ICONHRPortal.Data
{
    // Separation of concerns method TODo
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly ICONHRContext _IconhrContext = null;
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Entities;

        public GenericRepository(ICONHRContext context)
        {
            Context = context;
            _IconhrContext = context;
            Entities = Context.Set<TEntity>();
        }

        protected DbContext IConHrDbContextContext
        {
            get { return Context ?? new ICONHRContext(); }
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            Entities.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public TEntity Get(long id)
        {
            return Entities.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }


        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).AsQueryable();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        //TEntity Single(Func<TEntity, bool> predicate);
        //TEntity First(Func<TEntity, bool> predicate);

        public IQueryable<TEntity> GetQueryWithIncludeById(TEntity entity, string toInclude)
        {
            Entities.Include(toInclude);
            return Entities;
        }

        public IQueryable<TEntity> GetQueryWithInclude(TEntity entity, string toInclude)
        {
             Entities.Include(toInclude);
            return Entities;
        }

        public IQueryable<TEntity> GetQueryWithMultipleInclude(string[] includes)
        {
            foreach (string include in includes)
            {
                Entities.Include(include);
            }
            return Entities;
        }
    }
}

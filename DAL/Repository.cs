using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;

namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DataContext Context;
        public Repository(DataContext context)
        {
            this.Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(int id)
        {
            TEntity entity = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}

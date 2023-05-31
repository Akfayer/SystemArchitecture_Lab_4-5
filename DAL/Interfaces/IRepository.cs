using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(int id);
        void Update(TEntity entity);
    }
}

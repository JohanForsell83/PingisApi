using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pingis.DataModel.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        //Finding objects
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //Adding objects
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Removing objects
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void RemoveById(int id);

        //Update
        void Update(TEntity entity);
    }
}

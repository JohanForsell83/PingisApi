using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.Core.Models;
using Pingis.DataModel.Core.Repository;
using Pingis.DataModel.Core.Service;

namespace Pingis.DataModel.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        
        public void Create(TEntity entity)
        {
            _repository.Add(entity);
        }
        
        public void Update(TEntity entity)
        {
            _repository.Update(entity);        
        }
            
        public void Delete(int id)
        {
            _repository.RemoveById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.Get(id);
        }

    }
}

using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrucure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext storeContext;
        private Hashtable _repositories;

        public UnitOfWork(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public async Task<int> Complete()
        {
            return await storeContext.SaveChangesAsync();
        }

        public void Dispose()
        {
           storeContext.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories== null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if(!_repositories.ContainsKey(type))
            {
                var RepositoriesType = typeof(GenericRepository<>);

                var RepositoriesInstance = Activator.CreateInstance(RepositoriesType.MakeGenericType(typeof(TEntity)) , storeContext);
                _repositories.Add(type, RepositoriesInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type]; 
        }
    }
}

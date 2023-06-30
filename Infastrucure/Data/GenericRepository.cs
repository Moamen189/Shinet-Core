using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrucure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            this._storeContext = storeContext;
        }
        
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await _storeContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {

            return await _storeContext.Set<T>().FindAsync(id);
        }
    }
}

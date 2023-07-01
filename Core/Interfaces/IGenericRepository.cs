using Core.Entities;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> GetEntityWithSpec(ISpecification<T> specification);
        Task< IReadOnlyList<T> > GetListWithSpec(ISpecification<T> specification);

    }
}

using Core.Entities;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastrucure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery , ISpecification<TEntity> spec)
        {
            var query = InputQuery;

            if (spec.Criteria!= null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDesending != null)
            {
                query = query.OrderByDescending(spec.OrderByDesending);
            }

            query = spec.Includes.Aggregate(query , (current , include) => current.Include(include));

            return query;
        }
    }
}

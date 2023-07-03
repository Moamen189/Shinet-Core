using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
         
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy  { get; private set; }

    public Expression<Func<T, object>> OrderByDesending {get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void addIncludes (Expression<Func<T, object>>IncludesExpression)
        {
            Includes.Add(IncludesExpression);

        }

        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {
            OrderBy = OrderByExpression;

        }

        protected void AddOrderByDesending(Expression<Func<T, object>> OrderByDesendingExpression)
        {
            OrderByDesending= OrderByDesendingExpression;

        }

        protected void ApplyPagging(int skip , int take)
        {
            Take = take;
            Skip = skip;

            IsPagingEnabled= true;


        }
    }
}

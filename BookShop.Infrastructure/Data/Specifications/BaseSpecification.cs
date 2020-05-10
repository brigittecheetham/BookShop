using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BookShop.Infrastructure.Data.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        private readonly Expression<Func<T, bool>> _criteria;

        public BaseSpecification()
        {
            
        }

        public BaseSpecification(Expression<Func<T,bool>> criteria)
        {
            _criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria {get {return _criteria;}}

        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T,object>>>();

        public Expression<Func<T, object>> OrderBy {get; private set;}

        public Expression<Func<T, object>> OrderByDescending {get; private set;}

        public int Take {get; private set;}

        public int Skip {get; private set;}

        public bool IsPagingEnabled {get; private set;}

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
        protected void ApplyPaging(int skip, int take)
        {
            if (skip < 0) 
                skip = 0;

            if (take == 0)
                return;

            Take = take;
            Skip = skip;
            IsPagingEnabled = true;
            
        }
    }
}
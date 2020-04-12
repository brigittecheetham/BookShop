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

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
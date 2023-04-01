using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eventsApi.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAllEvents();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
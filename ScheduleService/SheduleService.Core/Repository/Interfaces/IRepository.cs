using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository.Interfaces
{
    public interface IRepository<T>
    {
        void AddIfNotExsist(T value, Expression<Func<T, bool>> predicate);
        void AddRange(IEnumerable<T> values);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Add(T value);
        void Remove(T value);
        void Detatch(T entity);
    }
}

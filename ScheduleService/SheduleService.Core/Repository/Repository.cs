using Microsoft.EntityFrameworkCore;
using SheduleService.Core.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheduleService.Core.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> _set { get; }

        public Repository(DbContext context)
        {
            _set = context.Set<T>();
        }

        public void Add(T value)
        {
            _set.Add(value);
        }

        public void AddRange(IEnumerable<T> values)
        {
            foreach (var item in values)
            {
                Add(item);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Remove(T value)
        {
            _set.Remove(value);
        }
    }
}

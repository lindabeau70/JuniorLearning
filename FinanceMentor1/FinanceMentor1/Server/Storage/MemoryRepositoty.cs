using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceMentor1.Server.Storage
{
    public class MemoryRepositoty<T> : IRepository<T>
    {
        private readonly IList<T> _entities;

        public MemoryRepositoty()
        {
            _entities = new List<T>();
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }
    }
}

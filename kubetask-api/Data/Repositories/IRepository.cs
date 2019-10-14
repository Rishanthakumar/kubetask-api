using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kubetask_api.Data.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> List();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task Update(T entity);
        Task<T> Get(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesService.Application.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

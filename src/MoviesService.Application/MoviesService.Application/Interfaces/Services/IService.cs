using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesService.Application.Interfaces.Services
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task Delete(Guid id);
        Task Create(T entity);
        Task Update(T entity);
    }
}

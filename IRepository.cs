using System.Collections.Generic;
using System.Threading.Tasks;


// interface that contains definitions for a group of related functionalities that a non-abstract class or a struct must implement.
namespace TodoApi
{
    public interface IRepository<T>
    {
        Task<List<T>> All();
        Task<T> Get(long id);
        Task<T> Create(T entity);
        Task Update(long id, T entity);
        Task<bool> Delete(long id);
    }
}
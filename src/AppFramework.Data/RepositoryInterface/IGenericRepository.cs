using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}

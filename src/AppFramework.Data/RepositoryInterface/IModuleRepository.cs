using AppFramework.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IModuleRepository : IGenericRepository<ModuleMaster>
    {
        Task<List<ModuleMaster>> GetModuleByFeatureIdAsync(int id);
        Task<List<ModuleMaster>> GetAllModule(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

    }
}

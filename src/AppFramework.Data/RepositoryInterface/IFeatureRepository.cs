using AppFramework.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IFeatureRepository : IGenericRepository<FeatureMaster>
    {
        Task<List<FeatureMaster>> GetAllFeature(int pageNumber, int pageSize,string searchKeyword, string sortBy, string sortOrder);

    }
}

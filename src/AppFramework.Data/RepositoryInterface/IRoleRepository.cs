using AppFramework.Domain.ApiModel.Role;
using AppFramework.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IRoleRepository : IGenericRepository<RoleMaster>
    {
        Task<List<RoleMaster>> GetAllRole(int pageNumber,int pageSize, string searchKeyword, string sortBy, string sortOrder);
        Task<List<RoleNavigationMapping>> GetRoleById(int roleId);
    }

}

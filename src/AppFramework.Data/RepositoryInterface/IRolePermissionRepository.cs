using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IRolePermissionRepository: IGenericRepository<RolePermissionMaster>
    {
        Task<List<RolePermissionMaster>> GetAllRolePermission(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);
    }
}

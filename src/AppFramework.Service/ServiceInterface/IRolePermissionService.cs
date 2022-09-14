using AppFramework.Domain.ApiModel.RolePermissions;
using AppFramework.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.ServiceInterface
{
    public interface IRolePermissionService
    {
        ServiceResult CreateRolePermission(AddRolePermission model);

        ServiceResult UpdateRolePermission(UpdateRolePermission model);

        ServiceResult GetAllRolePermission(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        ServiceResult GetRolePermissionById(int mappingId);
    }
}

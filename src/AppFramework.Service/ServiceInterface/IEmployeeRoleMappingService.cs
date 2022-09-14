using AppFramework.Domain.ApiModel.EmployeeRoleMapping;
using AppFramework.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.ServiceInterface
{
    public interface IEmployeeRoleMappingService
    {
        ServiceResult CreateEmployeeRoleMapping(AddEmployeeRoleMapping model);

        ServiceResult UpdateEmployeeRoleMapping(UpdateEmployeeRoleMapping model);

        ServiceResult GetAllEmployeeRoleMapping(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        ServiceResult GetEmployeeRoleMappingById(int mappingId);
    }
}

using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IEmployeeRoleMappingRepository: IGenericRepository<EmployeeRoleMappingMaster>
    {
        Task<List<EmployeeRoleMappingMaster>> GetAllEmployeeRoleMapping(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

    }
}

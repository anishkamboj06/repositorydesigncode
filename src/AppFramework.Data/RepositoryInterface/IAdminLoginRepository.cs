using AppFramework.Domain.ApiModel.Admin;
using AppFramework.Domain.ApiModel.CitizenManagement;
using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IAdminLoginRepository : IGenericRepository<AdminLoginMaster>
    {
        Task<AdminMaster> GetAsync(AdminLoginMaster entity);

        public Task<int> UpdateAsync(ChangePassword entity, string userType, string userId);
        Task<int> ResetEmployeePassword(int Id);
    }
}

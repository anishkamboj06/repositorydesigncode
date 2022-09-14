using AppFramework.Domain.ApiModel.Admin;
using AppFramework.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.ServiceInterface
{
    public interface IAdminLoginService
    {
        ServiceResult AdminLogin(AdminLogin model);
        ServiceResult UpdatePassword(ChangePassword model, string userType, string userId);
        ServiceResult ResetEmployeePassword(int Id);
    }
}

using AppFramework.Domain.ApiModel.CitizenManagement;
using AppFramework.Domain.ApiModel.EmployeeManagement;
using AppFramework.Domain.ApiModel.Profile;
using AppFramework.Domain.Model;
using AppFramework.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.ServiceInterface
{
    public interface IProfileService
    {
        ServiceResult GetEmployeeProfile(int profileId, string userType);
        ServiceResult GetCitizenProfile(int profileId, string userType);
        ServiceResult UpdateEmployeeProfile(UpdateEmployeeProfile model);
        ServiceResult UpdateCitizenProfile(UpdateCitizenProfile model);
        ServiceResult UploadProfileImage(int profileId, string userType, ProfileImage model);
        ServiceResult UpdateProfileImageById(UpdateProfileImage model);

    }
}

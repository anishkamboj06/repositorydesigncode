using AppFramework.Domain.ApiModel.Profile;
using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IProfileRepository
    {
        Task<EmployeeMaster> GetEmployeeProfile(int profileId, string userType);
        Task<CitizenMaster> GetCitizenProfile(int profileId, string userType);
        Task<int> UpdateEmployeeProfile(EmployeeMaster entity);
        Task<int> UpdateCitizenProfile(CitizenMaster entity);
        Task<int> UploadProfileImage(int profileId,string userType, ProfileImage model);
        Task<int> UpdateProfileImageById(UpdateProfileImage model);

    }
}

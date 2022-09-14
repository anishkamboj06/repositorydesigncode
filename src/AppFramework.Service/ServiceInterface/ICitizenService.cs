using AppFramework.Domain.ApiModel.CitizenManagement;
using AppFramework.Domain.ViewModel;

namespace AppFramework.Service.ServiceInterface
{
    public interface ICitizenService
    {
        ServiceResult CreateCitizen(AddCitizen model);

        ServiceResult UpdateCitizen(UpdateCitizen model);

        ServiceResult DeleteCitizen(int CitizenID);

        ServiceResult GetAllCitizen(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        ServiceResult GetCitizenById(int CitizenID);

        ServiceResult ForgotPassword(string emailId);

        ServiceResult ResetPassword(string OTP, string password);
        ServiceResult CitizenLogin(CitizenLogin model);
    }
}

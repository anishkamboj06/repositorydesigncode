using AppFramework.Domain.ApiModel.EmployeeManagement;
using AppFramework.Domain.ViewModel;

namespace AppFramework.Service.ServiceInterface
{
    public interface IEmployeeService
    {
        ServiceResult CreateEmployee(AddEmployee model);

        ServiceResult UpdateEmployee(UpdateEmployee model);

        ServiceResult DeleteEmployee(int EmployeeID);

        ServiceResult GetAllEmployee(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        ServiceResult GetEmployeeById(int EmployeeID);
        ServiceResult EmployeeLogin(EmployeeLogin model);

        ServiceResult ForgotPassword(string emailId);

        ServiceResult ResetPassword(string OTP, string password);

        ServiceResult GetEmployementType();

    }
}

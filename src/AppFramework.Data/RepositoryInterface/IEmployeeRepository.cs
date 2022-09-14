using AppFramework.Domain.ApiModel.EmployeeManagement;
using AppFramework.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IEmployeeRepository : IGenericRepository<EmployeeMaster>
    {
        Task<List<EmployeeMaster>> GetAllEmployee(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        Task<string> ForgotPassword(string email);

        Task<int> ResetPassword(string OTP, string password);
        Task<EmployeeLoginMaster> GetEmployeeLogin(EmployeeLoginMaster entity);
        Task<List<EmployementTypes>> GetEmployementType();

        Task<EmployeeMaster> GetEmployeeById(int EmployeeID);
    }
}

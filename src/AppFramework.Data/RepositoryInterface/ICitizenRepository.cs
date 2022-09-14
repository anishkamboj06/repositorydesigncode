﻿using AppFramework.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface ICitizenRepository : IGenericRepository<CitizenMaster>
    {
        Task<List<CitizenMaster>> GetAllCitizen(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        Task<string> ForgotPassword(string email);

        Task<int> ResetPassword(string OTP, string password);
        Task<CitizenLoginMaster> GetCitizenLogin(CitizenLoginMaster entity);
    }
}

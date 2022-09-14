using AppFramework.Data.RepositoryInterface;
using AppFramework.Domain.ApiModel.Admin;
using AppFramework.Domain.Model;
using AppFramework.Utility.DataConfig;
using AppFramework.Utility.EncryptDecrypt;
using AppFramework.Utility.ErrorLog;
using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.Repository
{
    public class AdminLoginRepository : IAdminLoginRepository
    {
        private readonly IMapper _mapper;
        private readonly ILogError _logError;
        private readonly IConfiguration _configuration;
        public AdminLoginRepository(IConfiguration configuration, IMapper mapper, ILogError logError)
        {
            _mapper = mapper;
            _logError = logError;
            _configuration = configuration;
        }
        public Task<int> AddAsync(AdminLoginMaster entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(AdminLoginMaster entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<AdminMaster> GetAsync(AdminLoginMaster entity)
        {
            AdminMaster adminMaster = new AdminMaster();
            try
            {
                string procedure = Procedure.AdminLogin;
                entity.UserPassword=Encryption.EncodeToBase64(entity.UserPassword);
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await (connection.QuerySingleAsync<AdminMaster>(procedure, entity, commandType: CommandType.StoredProcedure));
                    adminMaster = _mapper.Map<AdminMaster>(obj);
                }
            }
            catch (Exception ex)
            {

                _logError.WriteTextToFile("GetAsync Admin Login : ", ex.Message, ex.HResult, ex.StackTrace);
            }
            return adminMaster;
        }

        public Task<AdminLoginMaster> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(ChangePassword entity, string userType, string userId)
        {
            int result = 0;
            string procedure = string.Empty;
            object values;
            try
            {
                entity.OldPassword = Encryption.EncodeToBase64(entity.OldPassword);
                entity.NewPassword = Encryption.EncodeToBase64(entity.NewPassword);
                values = new
                {
                    Id = userId,
                    OldPassword = entity.OldPassword,
                    NewPassword = entity.NewPassword,
                    UserType = userType,
                    ModifiedBy = userId
                };
                procedure = Procedure.ChangePassword;
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt32(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {

                _logError.WriteTextToFile("Change Password : ", ex.Message,ex.HResult,ex.StackTrace);
            }
            return result;
        }

        public async Task<int> ResetEmployeePassword(int Id)
        {
            int result = 0;
            try
            {
                var values = new { Id = Id };
                var procedure = Procedure.ResetEmployeePassword;
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt32(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {

                _logError.WriteTextToFile("Reset Password : ", ex.Message,ex.HResult,ex.StackTrace);
            }
            return result;
        }
    }
}

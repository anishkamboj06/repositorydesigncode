using AppFramework.Data.RepositoryInterface;
using AppFramework.Domain.ApiModel.RolePermissions;
using AppFramework.Domain.Model;
using AppFramework.Utility.DataConfig;
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
    public class RolePermissionRepository : IRolePermissionRepository
    {

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogError _logError;
        public RolePermissionRepository(IMapper mapper, IConfiguration configuration, ILogError logError)
        {
            _logError = logError;
            _mapper = mapper;
            _configuration = configuration;
        }
        /// <summary>
        /// Create All Role Permission
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(RolePermissionMaster entity)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.SaveRolePermission;
                var values = _mapper.Map<AddRolePermission>(entity);
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Role Permission : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// Delete Role Permission
        /// </summary>
        /// <param name="mappingId"></param>
        /// <returns></returns>

        /// <summary>
        /// Get Role Permission
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public async Task<List<RolePermissionMaster>> GetAllRolePermission(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {
            List<RolePermissionMaster> lstRolePermission = new List<RolePermissionMaster>();
            try
            {
                var procedure = Procedure.GetAllRolePermission;
                var value = new { PageNumber = pageNumber, PageSize = pageSize, SearchKeyword = searchKeyword, SortBy = sortBy, SortOrder = sortOrder };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QueryAsync<RolePermissionMaster>(procedure, value, commandType: CommandType.StoredProcedure);
                    lstRolePermission = _mapper.Map<List<RolePermissionMaster>>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All RolePermission : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return lstRolePermission;
        }

        /// <summary>
        /// Get Role Permission By Id
        /// </summary>
        /// <param name="mappingId"></param>
        /// <returns></returns>
        public async Task<RolePermissionMaster> GetByIdAsync(int mappingId)
        {
            RolePermissionMaster RolePermissionMaster = new RolePermissionMaster();
            try
            {
                var procedure = Procedure.GetRolePermissionById;
                var values = new { MappingId = mappingId };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QuerySingleAsync<RolePermissionMaster>(procedure, values, commandType: CommandType.StoredProcedure);
                    RolePermissionMaster = _mapper.Map<RolePermissionMaster>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get RolePermission By Id : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return RolePermissionMaster;
        }

        /// <summary>
        /// Update Role Permission
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(RolePermissionMaster entity)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.UpdateRolePermission;
                var values = _mapper.Map<UpdateRolePermission>(entity);
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Role Permission : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }


        public Task<int> DeleteAsync(int mappingId)
        {
            throw new NotImplementedException();
        }

        public Task<List<RolePermissionMaster>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}

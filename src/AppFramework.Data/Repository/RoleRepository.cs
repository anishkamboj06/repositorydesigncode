using AppFramework.Data.RepositoryInterface;
using AppFramework.Domain.ApiModel.Role;
using AppFramework.Domain.ApiModel.RoleNavigation;
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
using System.Threading.Tasks;

namespace AppFramework.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogError _logError;
        public RoleRepository(IMapper mapper, IConfiguration configuration, ILogError logError)
        {
            _logError = logError;
            _mapper = mapper;
            _configuration = configuration;
        }

        /// <summary>
        /// Add 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(RoleMaster entity)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.SaveRole;
                var values = new { RoleTitle = entity.RoleTitle, IsActive = true, CreatedOn = DateTime.Now, CreatedBy = 1, DepartmentId = entity.DepartmentId };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Role : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(RoleMaster entity)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.UpdateRole;
                var values = _mapper.Map<UpdateRole>(entity);
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Role : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int roleId)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.DeleteRole;
                var values = new { RoleId = roleId, IsDelete = true };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Delete Role : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }


        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<List<RoleNavigationMapping>> GetRoleById(int roleId)
        {
            List<RoleNavigationMapping> roleMaster = new List<RoleNavigationMapping>();
            try
            {
                var procedure = Procedure.GetRoleById;
                var values = new { RoleId = roleId };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QueryAsync<AddRoleNavigation>(procedure, values, commandType: CommandType.StoredProcedure);
                    var data = obj.GroupBy(a => new { a.RoleId, a.FeatureId }).Select(x => new RoleNavigationMapping
                    {
                        RoleId = x.Key.RoleId,
                        FeatureId = x.Key.FeatureId,
                        DepartmentId = x.Select(z=>z.DepartmentId).FirstOrDefault(),
                        RoleTitle = x.Select(z => z.RoleTitle).FirstOrDefault(),
                        NavList = x.Select(z => new Navigations { NavigationIds = z.NavigationId }).ToList()
                    }).ToList();
                    roleMaster = _mapper.Map<List<RoleNavigationMapping>>(data);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Role By Id : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return roleMaster;
        }


        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public async Task<List<RoleMaster>> GetAllRole(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {

            List<RoleMaster> lstRole = new List<RoleMaster>();
            try
            {
                var procedure = Procedure.GetAllRole;
                var value = new { PageNumber = pageNumber, PageSize = pageSize, SearchKeyword = searchKeyword, SortBy = sortBy, SortOrder = sortOrder };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QueryAsync<RoleMaster>(procedure, value, commandType: CommandType.StoredProcedure);
                    lstRole = _mapper.Map<List<RoleMaster>>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Role : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return lstRole;
        }

        public Task<RoleMaster> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
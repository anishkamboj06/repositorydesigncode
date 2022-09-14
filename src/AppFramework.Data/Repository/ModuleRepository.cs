using AppFramework.Data.RepositoryInterface;
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
using System.Threading.Tasks;

namespace AppFramework.Data.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogError _logError;
        public ModuleRepository(IMapper mapper, IConfiguration configuration,ILogError logError)
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
        public async Task<int> AddAsync(ModuleMaster entity)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.SaveModule;
                var values = new { FeatureId = entity.FeatureId, ModuleTitle = entity.ModuleTitle, Description = entity.Description, IsActive = true, CreatedOn = DateTime.Now, CreatedBy = 1 };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Module : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(ModuleMaster entity)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.UpdateModule;
                var values = new { ModuleId = entity.ModuleId, FeatureId = entity.FeatureId, ModuleTitle = entity.ModuleTitle, Description = entity.Description, ModifiedBy = 1, ModifiedOn = DateTime.Now };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Module : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="moduleIdd"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int moduleIdd)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.DeleteModule;
                var values = new { ModuleId = moduleIdd, IsDelete = true };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Delete Module : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async Task<ModuleMaster> GetByIdAsync(int moduleId)
        {
            ModuleMaster moduleMaster = new ModuleMaster();
            try
            {
                var procedure = Procedure.GetModuleById;
                var values = new { ModuleId = moduleId };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QuerySingleAsync<ModuleMaster>(procedure, values, commandType: CommandType.StoredProcedure);
                    moduleMaster = _mapper.Map<ModuleMaster>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Module By Id : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return moduleMaster;
        }

        /// <summary>
        /// Get Module By Feature Id
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns></returns>
        public async Task<List<ModuleMaster>> GetModuleByFeatureIdAsync(int featureId)
        {
            List<ModuleMaster> moduleMaster = new List<ModuleMaster>();
            try
            {
                var procedure = Procedure.GetModuleByFeatureId;
                var values = new { FeatureId= featureId };
                using (var con= new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    con.Open();
                    var obj = await con.QueryAsync<ModuleMaster>(procedure,values,commandType:CommandType.StoredProcedure);
                    moduleMaster = _mapper.Map<List<ModuleMaster>>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Module By Feature Id : ", ex.Message, ex.HResult, ex.StackTrace);
            }
            return moduleMaster;
        }

        /// <summary>
        /// Get All Modules
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>

        public async Task<List<ModuleMaster>> GetAllModule(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {
            List<ModuleMaster> lstModule = new List<ModuleMaster>();
            try
            {
                var procedure = Procedure.GetAllModule;
                var value = new { PageNumber = pageNumber, PageSize = pageSize, SearchKeyword = searchKeyword, SortBy=sortBy,SortOrder=sortOrder };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QueryAsync<ModuleMaster>(procedure,value ,commandType: CommandType.StoredProcedure);
                    lstModule = _mapper.Map<List<ModuleMaster>>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Module : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return lstModule;
        }
    }
}

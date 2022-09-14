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
    public class FeatureRepository : IFeatureRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogError _logError;
        public FeatureRepository(IMapper mapper, IConfiguration configuration,ILogError logError)
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
        public async Task<int> AddAsync(FeatureMaster entity)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.SaveFeature;
                var values = new { FeatureTitle = entity.FeatureTitle, ShortCode = entity.ShortCode, IsActive = true, CreatedOn = DateTime.Now, CreatedBy = 1 };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Feature : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(FeatureMaster entity)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.UpdateFeature;
                var values = new { FeatureId = entity.FeatureId, FeatureTitle = entity.FeatureTitle, ShortCode = entity.ShortCode, ModifiedBy = 1, ModifiedOn = DateTime.Now };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Feature : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(int featureId)
        {
            int result = 0;
            try
            {
                var procedure = Procedure.DeleteFeature;
                var values = new { FeatureId = featureId, IsDelete = true };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt16(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Delete Feature : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns></returns>
        public async Task<FeatureMaster> GetByIdAsync(int featureId)
        {
            FeatureMaster featureMaster = new FeatureMaster();
            try
            {
                var procedure = Procedure.GetFeatureById;
                var values = new { FeatureId = featureId };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QuerySingleAsync<FeatureMaster>(procedure, values, commandType: CommandType.StoredProcedure);
                    featureMaster = _mapper.Map<FeatureMaster>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Feature By Id : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return featureMaster;
        }

        /// <summary>
        /// Get All Features
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public async Task<List<FeatureMaster>> GetAllFeature(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {
            List<FeatureMaster> lstFeature = new List<FeatureMaster>();
            try
            {
                var procedure = Procedure.GetAllFeature;
                var value = new { PageNumber = pageNumber, PageSize = pageSize, SearchKeyword = searchKeyword,SortBy=sortBy,SortOrder=sortOrder };
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QueryAsync<FeatureMaster>(procedure,value, commandType: CommandType.StoredProcedure);
                    lstFeature = _mapper.Map<List<FeatureMaster>>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Features : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return lstFeature;
        }
    }
}

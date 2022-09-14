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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogError _logError;
        public DepartmentRepository(IMapper mapper, IConfiguration configuration,ILogError logError)
        {
            _mapper = mapper;
            _configuration = configuration;
            _logError = logError;
        }
        public Task<int> AddAsync(DepartmentMaster entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DepartmentMaster>> GetAllAsync()
        {
            List<DepartmentMaster> lstEmployee = new List<DepartmentMaster>();
            try
            {
                var procedure = Procedure.GetAllDepartment;
                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    var obj = await connection.QueryAsync<DepartmentMaster>(procedure, commandType: CommandType.StoredProcedure);
                    lstEmployee = _mapper.Map<List<DepartmentMaster>>(obj);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Department : " , ex.Message,ex.HResult,ex.StackTrace);
            }
            return lstEmployee;
        }

        public Task<DepartmentMaster> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(DepartmentMaster entity)
        {
            throw new NotImplementedException();
        }
    }
}

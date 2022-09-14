using AppFramework.Data.RepositoryInterface;
using AppFramework.Domain.ApiModel.Relieving;
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
    public class RelievingRepository : IRelievingRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogError _logError;
        public RelievingRepository(IMapper mapper, IConfiguration configuration,ILogError logError)
        {
            _logError = logError;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<int> AddAsync(RelievingMaster entity)
        {
            int result = 0;
            try
            {
                var values = _mapper.Map<AddRelieving>(entity);
                var procedure = Procedure.SaveRelieving;

                using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString")))
                {
                    connection.Open();
                    result = Convert.ToInt32(await connection.ExecuteScalarAsync(procedure, values, commandType: CommandType.StoredProcedure));
                }

            }
            catch (Exception ex)
            {

                _logError.WriteTextToFile("Create Relieving : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return result;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RelievingMaster> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(RelievingMaster entity)
        {
            throw new NotImplementedException();
        }
    }
}

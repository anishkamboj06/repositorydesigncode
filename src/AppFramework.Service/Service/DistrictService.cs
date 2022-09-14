using AppFramework.Data.RepositoryInterface;
using AppFramework.Domain.ViewModel;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility.ErrorLog;
using AppFramework.Utility.MessageConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.Service
{
    public class DistrictService:IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly ILogError _logError;
        public DistrictService(IDistrictRepository districtRepository,ILogError logError)
        {
            _logError = logError;
            _districtRepository = districtRepository;
        }
        /// <summary>
        /// Get District By State Id
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public ServiceResult GetDistrictByStateId(int stateId)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                var result = _districtRepository.GetDistrictByStateId(stateId);
                if (result != null)
                {
                    serviceResult.Message = MessageConfig.Success;
                    serviceResult.ResultData = result.Result;
                    serviceResult.Status = true;
                    serviceResult.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                }
                else
                {
                    serviceResult.Message = MessageConfig.ErrorOccurred;
                    serviceResult.ResultData = null;
                    serviceResult.Status = false;
                    serviceResult.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get District By State Id : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return serviceResult;
        }
    }
}

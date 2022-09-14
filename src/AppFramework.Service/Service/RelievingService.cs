using AppFramework.Data.RepositoryInterface;
using AppFramework.Domain.ApiModel.Relieving;
using AppFramework.Domain.Model;
using AppFramework.Domain.ViewModel;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility.ErrorLog;
using AppFramework.Utility.MessageConfig;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.Service
{
    public class RelievingService : IRelievingService
    {
        private readonly IRelievingRepository _relievingRepository;
        private readonly IMapper _mapper;
        private readonly ILogError _logError;
        public RelievingService(IRelievingRepository RelievingRepository, IMapper mapper, ILogError logError)
        {
            _logError = logError;
            _relievingRepository = RelievingRepository;
            _mapper = mapper;
        }

        public ServiceResult CreateRelieving(AddRelieving model)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                var obj = _mapper.Map<RelievingMaster>(model);
                var _result = _relievingRepository.AddAsync(obj);

                if (_result != null)
                {
                    serviceResult.ResultData = _result.Result;
                    if (serviceResult.ResultData == 1)
                    {
                        serviceResult.Message = MessageConfig.RecordSaved;
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
                serviceResult.Message = MessageConfig.ErrorOccurred;
                serviceResult.ResultData = null;
                serviceResult.Status = false;
                serviceResult.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                _logError.WriteTextToFile("Create Relieving : " , ex.Message, ex.HResult, ex.StackTrace);
            }
            return serviceResult;
        }

    }
}

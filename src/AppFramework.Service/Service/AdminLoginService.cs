using AppFramework.Data.RepositoryInterface;
using AppFramework.Domain.ApiModel.Admin;
using AppFramework.Domain.Model;
using AppFramework.Domain.ViewModel;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility;
using AppFramework.Utility.ErrorLog;
using AppFramework.Utility.MessageConfig;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static AppFramework.Domain.CommonEnam.UserTypeEnum;

namespace AppFramework.Service.Service
{
    public class AdminLoginService : IAdminLoginService
    {
        private readonly IMapper _mapper;
        private readonly IAdminLoginRepository _adminLoginRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogError _logError;
        private readonly IBlobService _blobService;

        public AdminLoginService(IMapper mapper, IAdminLoginRepository adminLoginRepository, IConfiguration configuration, ILogError logError,IBlobService blobService)
        {
            _logError = logError;
            _mapper = mapper;
            _adminLoginRepository = adminLoginRepository;
            _configuration = configuration;
            _blobService = blobService;

        }
        public ServiceResult AdminLogin(AdminLogin model)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                string blobAccessKey = _configuration.GetConnectionString("ProfileBlobStorageAccessKey");
                string containerName = _configuration["BlobContainers:ProfileImage"];
                var obj = _mapper.Map<AdminLoginMaster>(model);
                var result = _adminLoginRepository.GetAsync(obj);
                if (result.Result.EmployeeID == 0)
                {
                    serviceResult.Message = MessageConfig.InvalidEmailPassword;
                    serviceResult.ResultData = null;
                    serviceResult.Status = false;
                    serviceResult.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);

                }
                else
                {
                    result.Result.Token = JWTBearerAuthentication.GenerateJSONWebToken(model.Email, Convert.ToString(result.Result.EmployeeID), nameof(UserType.Admin), _configuration);
                    var data = _blobService.FetchBlobUsingFileReferenceType(blobAccessKey, containerName, result.Result.ImageReference);
                    if (data.Result.ResultData != null)
                    {
                        result.Result.ImageCode = data.Result.ResultData;
                    }
                    else
                    {
                        result.Result.ImageCode = null;
                    }
                    serviceResult.Message = MessageConfig.Success;
                    serviceResult.ResultData = result.Result;
                    serviceResult.Status = true;
                    serviceResult.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Admin Login : ", ex.Message, ex.HResult, ex.StackTrace);
            }
            return serviceResult;
        }

        public ServiceResult UpdatePassword(ChangePassword model, string userType, string userId)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                var _result = _adminLoginRepository.UpdateAsync(model, userType, userId);
                if (_result != null)
                {
                    serviceResult.ResultData = _result.Result;
                    if (serviceResult.ResultData == 1)
                    {
                        serviceResult.Message = MessageConfig.RecordUpdated;
                        serviceResult.Status = true;
                        serviceResult.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                    }
                    else if (serviceResult.ResultData == 2)
                    {
                        serviceResult.Message = MessageConfig.WrongPassword;
                        serviceResult.ResultData = null;
                        serviceResult.Status = false;
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
                _logError.WriteTextToFile("Change Password : ", ex.Message, ex.HResult, ex.StackTrace);
            }
            return serviceResult;
        }

        public ServiceResult ResetEmployeePassword(int Id)
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                var result = _adminLoginRepository.ResetEmployeePassword(Id);
                if (result.Result == 1)
                {

                    serviceResult.Message = MessageConfig.PasswordUpdated;
                    serviceResult.ResultData = result.Result; ;
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
                _logError.WriteTextToFile("Reset Employee Password : ", ex.Message, ex.HResult, ex.StackTrace);
            }
            return serviceResult;
        }
    }
}

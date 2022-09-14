using AppFramework.Domain.ApiModel.Admin;
using AppFramework.Domain.ViewModel;
using AppFramework.Service.Service;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility.ErrorLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFramework.Web.Controllers
{
    [Route("api/AdminLogin")]
    public class AdminController : Controller
    {
        private readonly IAdminLoginService _adminservice;
        private readonly ILogError _logError;

        public AdminController(IAdminLoginService adminservice, ILogError logError)
        {
            _adminservice = adminservice;
            _logError = logError;
        }
        [HttpPost]
        public IActionResult AdminLogin([FromBody] AdminLogin model)
        {
            try
            {
                ServiceResult data = _adminservice.AdminLogin(model);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Admin Login : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromBody] ChangePassword model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string userType = HttpContext.User.Claims.First(x => x.Type == "UserType").Value;
                    string userId = HttpContext.User.Claims.First(x => x.Type == "UserID").Value;
                    var data = _adminservice.UpdatePassword(model, userType, userId);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Change Password : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [Route("ResetEmployeePassword")]
        public IActionResult ResetEmployeePassword(int Id)
        {
            try
            {
                var data = _adminservice.ResetEmployeePassword(Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Reset Employee Password : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }
}

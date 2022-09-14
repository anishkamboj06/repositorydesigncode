using AppFramework.Domain.ApiModel.Navigation;
using AppFramework.Domain.Model;
using AppFramework.Domain.ViewModel;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility.DataConfig;
using AppFramework.Utility.ErrorLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppFramework.Web.Controllers
{
    [Route("api/navigation")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    public class NavigationController : Controller
    {
        private readonly INavigationService _navigationService;
        private readonly ILogError _logError;
        public NavigationController(INavigationService navigationService, ILogError logError)
        {
            _navigationService = navigationService;
            _logError = logError;
        }

        /// <summary>
        /// Create Navigation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateNavigation([FromBody] AddNavigation model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServiceResult data = _navigationService.CreateNavigation(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Navigation : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateNavigation([FromBody] UpdateNavigation model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _navigationService.UpdateNavigation(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Navigation : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Get All Navigations
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllNavigations(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {
            try
            {
                var data = _navigationService.GetAllNavigations(pageNumber, pageSize, searchKeyword, sortBy, sortOrder);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Navigation : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete Navigation
        /// </summary>
        /// <param name="navigationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{navigationId}")]
        public IActionResult DeleteNavigation(int navigationId)
        {
            try
            {
                var data = _navigationService.DeleteNavigation(navigationId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Delete Navigation : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("{navigationId}")]
        public IActionResult GetNavigationById(int navigationId)
        {
            try
            {
                var data = _navigationService.GetNavigationById(navigationId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Navigation By Id : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetNavigation")]
        public IActionResult GetNavigation()
        {
            try
            {
                int Id = 0;
                string UserType = string.Empty;
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    Id = Convert.ToInt32(identity.FindFirst("UserID").Value);
                    UserType = identity.FindFirst("UserType").Value;
                }
                var data = _navigationService.GetNavigation(Id,UserType);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Navigation : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }
}

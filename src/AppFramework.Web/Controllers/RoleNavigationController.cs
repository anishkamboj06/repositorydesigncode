using AppFramework.Domain.ApiModel.RoleNavigation;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility.ErrorLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFramework.Web.Controllers
{
    [Route("api/roleNavigation")]
    public class RoleNavigationController : Controller
    {
        private readonly IRoleNavigationService _RoleNavigationService;
        private readonly ILogError _logError;

        public RoleNavigationController(IRoleNavigationService RoleNavigationService, ILogError logError)
        {
            _RoleNavigationService = RoleNavigationService;
            _logError = logError;
        }

        /// <summary>
        /// Create RoleNavigation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateRoleNavigation([FromBody] AddRoleNavigation model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _RoleNavigationService.CreateRoleNavigation(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Role Navigation : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update RoleNavigation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateRoleNavigation([FromBody] UpdateRoleNavigation model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _RoleNavigationService.UpdateRoleNavigation(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Role Navigation : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }



        /// <summary>
        /// Get All RoleNavigations
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllRoleNavigations(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {
            try
            {
                var data = _RoleNavigationService.GetAllRoleNavigation(pageNumber, pageSize, searchKeyword, sortBy, sortOrder);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Role Navigations : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get RoleNavigation By Id
        /// </summary>
        /// <param name="mappingId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mappingId}")]
        public IActionResult GetRoleNavigationById(int mappingId)
        {
            try
            {
                var data = _RoleNavigationService.GetRoleNavigationById(mappingId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Role Navigation By Id : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }
}



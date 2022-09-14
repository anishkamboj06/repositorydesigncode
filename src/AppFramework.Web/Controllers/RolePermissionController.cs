using AppFramework.Domain.ApiModel.RolePermissions;
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
    [Route("api/rolePermission")]
    public class RolePermissionController : Controller
    {
        private readonly IRolePermissionService _RolePermissionService;
        private readonly ILogError _logError;

        public RolePermissionController(IRolePermissionService RolePermissionService, ILogError logError)
        {
            _RolePermissionService = RolePermissionService;
            _logError = logError;
        }

        /// <summary>
        /// Create RolePermission
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateRolePermission([FromBody] AddRolePermission model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _RolePermissionService.CreateRolePermission(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Role Permission : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update RolePermission
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateRolePermission([FromBody] UpdateRolePermission model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _RolePermissionService.UpdateRolePermission(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Role Permission : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }



        /// <summary>
        /// Get All RolePermissions
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllRolePermissions(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {
            try
            {
                var data = _RolePermissionService.GetAllRolePermission(pageNumber, pageSize, searchKeyword, sortBy, sortOrder);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Role Permissions : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get RolePermission By Id
        /// </summary>
        /// <param name="mappingId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mappingId}")]
        public IActionResult GetRolePermissionById(int mappingId)
        {
            try
            {
                var data = _RolePermissionService.GetRolePermissionById(mappingId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Role Permission By Id : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }

}

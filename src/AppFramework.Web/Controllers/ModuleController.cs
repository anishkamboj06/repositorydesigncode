using AppFramework.Domain.ApiModel.Module;
using AppFramework.Domain.ViewModel;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility.ErrorLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AppFramework.Web.Controllers
{
    [Route("api/module")]
    public class ModuleController : Controller
    {
        private readonly IModuleService _moduleService;
        private readonly ILogError _logError;

        public ModuleController(IModuleService moduleService, ILogError logError)
        {
            _moduleService = moduleService;
            _logError = logError;
        }
        /// <summary>
        /// Create Module
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateModule([FromBody] AddModule model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServiceResult data = _moduleService.CreateModule(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Module : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update Module
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateModule([FromBody] UpdateModule model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _moduleService.UpdateModule(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Module : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete Module
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteModule(int moduleId)
        {
            try
            {
                var data = _moduleService.DeleteModule(moduleId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Delete Module : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get All Modules 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllModules(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {
            try
            {
                var data = _moduleService.GetAllModule(pageNumber, pageSize, searchKeyword, sortBy, sortOrder);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Modules : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get Module By Id
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{moduleId}")]
        public IActionResult GetModuleById(int moduleId)
        {
            try
            {
                var data = _moduleService.GetModuleById(moduleId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Module By Id : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get Module By Feature Id
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{featureId}")]
        public IActionResult GetModuleByFeatureId(int featureId)
        {
            try
            {
                var data = _moduleService.GetModuleByFeatureId(featureId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Module By Feature Id : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }
}

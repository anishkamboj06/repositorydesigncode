using AppFramework.Domain.ApiModel.Feature;
using AppFramework.Domain.ViewModel;
using AppFramework.Service.ServiceInterface;
using AppFramework.Utility.ErrorLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace AppFramework.Web.Controllers
{
    [Route("api/feature")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly ILogError _logError;

        public FeatureController(IFeatureService featureService, ILogError logError)
        {
            _featureService = featureService;
            _logError = logError;
        }

        /// <summary>
        /// Create Feature
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult CreateFeature([FromBody] AddFeature model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServiceResult data = _featureService.CreateFeature(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Feature : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Update Feature
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateFeature([FromBody] UpdateFeature model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _featureService.UpdateFeature(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Update Feature : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete Feature
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteFeature(int featureId)
        {
            try
            {
                var data = _featureService.DeleteFeature(featureId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Delete Feature : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get All Features
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKeyword"></param>
        /// <param name="sortBy"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllFeatures(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder)
        {
            try
            {
                var data = _featureService.GetAllFeature(pageNumber, pageSize, searchKeyword, sortBy, sortOrder);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get All Features : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get Feature By Id
        /// </summary>
        /// <param name="featureId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{featureId}")]
        public IActionResult GetFeatureById(int featureId)
        {
            try
            {
                var data = _featureService.GetFeatureById(featureId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Feature By Id : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }

    }
}

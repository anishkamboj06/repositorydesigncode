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
    [Route("api/district")]
    public class DistrictController : Controller
    {
        public readonly IDistrictService _districtService;
        private readonly ILogError _logError;
        public DistrictController(ILogError logError, IDistrictService districtService)
        {
            _districtService = districtService;
            _logError = logError;
        }
        /// <summary>
        /// Get Disitrict By State Id
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{stateId}")]
        public IActionResult GetDistrictByStateId(int stateId)
        {
            try
            {
                if (stateId == 0)
                {
                    return BadRequest();
                }
                else
                {
                    var data = _districtService.GetDistrictByStateId(stateId);
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get District By State Id : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }
}

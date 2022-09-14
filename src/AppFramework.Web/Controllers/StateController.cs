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
    [Route("api/state")]
    public class StateController : Controller
    {
        public readonly IStateService _stateService;
        private readonly ILogError _logError;

        public StateController(ILogError logError, IStateService stateService)
        {
            _stateService = stateService;
            _logError = logError;
        }

        /// <summary>
        /// Get State
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetState()
        {
            try
            {
                var data = _stateService.GetAllState();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get State : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }


    }
}

using AppFramework.Domain.ApiModel.Relieving;
using AppFramework.Domain.ViewModel;
using AppFramework.Service.ServiceInterface;
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
    [Route("api/relieving")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class RelievingController : Controller
    {
        private readonly IRelievingService _RelievingService;
        private readonly ILogError _logError;
        public RelievingController(IRelievingService RelievingService, ILogError logError)
        {
            _RelievingService = RelievingService;
            _logError = logError;
        }

        /// <summary>
        /// Create Relieving
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateRelieving([FromBody] AddRelieving model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    if (identity != null)
                    {
                        IEnumerable<Claim> claims = identity.Claims;
                        model.EmployeeId = Convert.ToInt32(identity.FindFirst("UserID").Value);
                    }
                    ServiceResult data = _RelievingService.CreateRelieving(model);
                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Create Relieving : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }
    }    
}

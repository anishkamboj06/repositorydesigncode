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
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        public readonly IDepartmentService _departmentService;
        private readonly ILogError _logError;

        public DepartmentController(ILogError logError, IDepartmentService departmentService)
        {
            _departmentService = departmentService;
            _logError = logError;
        }

        /// <summary>
        /// Get Department
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDepartment()
        {
            try
            {
                var data = _departmentService.GetAllDepartment();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logError.WriteTextToFile("Get Department : ", ex.Message, ex.HResult, ex.StackTrace);
                return BadRequest(ex);
            }
        }


    }
}

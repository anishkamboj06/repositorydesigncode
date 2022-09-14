﻿using AppFramework.Service.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFramework.Web.Controllers
{

    [Route("api/log")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]

    public class LogController : Controller
    {
        private readonly ILogService _logService;
        private readonly ILogger _logger;

        public LogController(ILogService logService, ILoggerFactory logFactory)
        {
            _logService = logService;
            _logger = logFactory.CreateLogger<LogController>();
        }
        [HttpGet]
        public IActionResult GetAllLogs(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder, DateTime? startDate =null, DateTime? endDate=null,string type=null)
        {
            try
            {
                var data = _logService.GetAllLog(pageNumber, pageSize, searchKeyword, sortBy, sortOrder,startDate,endDate,type);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.Log(0, ex.Message);
                return BadRequest(ex);
            }
        }
    }
}

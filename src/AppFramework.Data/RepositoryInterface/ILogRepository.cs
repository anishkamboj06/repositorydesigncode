﻿using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface ILogRepository
    {
        Task<List<LogMaster>> GetAllLog(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder, DateTime? startDate, DateTime? endDate, string type);
    }
}

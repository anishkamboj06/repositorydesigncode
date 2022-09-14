﻿using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IWorkflowProcessRepository:IGenericRepository<WorkflowProcessMaster>
    {
        Task<List<WorkflowProcessMaster>> GetAllWFProcess(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

    }
}

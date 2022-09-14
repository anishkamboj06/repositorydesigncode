﻿using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IWorkflowStageRepository:IGenericRepository<WorkflowStageMaster>
    {
        Task<int> DeleteWFStageAsync(long stageId);
        Task<WorkflowStageMaster> GetWFStageByIdAsync(long stageId);
        Task<List<WorkflowStageMaster>> GetAllWFStage(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

    }
}

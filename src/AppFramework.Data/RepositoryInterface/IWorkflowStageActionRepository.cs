using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Data.RepositoryInterface
{
    public interface IWorkflowStageActionRepository:IGenericRepository<WorkflowStageActionMaster>
    {
        Task<int> DeleteWFStageActionAsync(long actionId);
        Task<WorkflowStageActionMaster> GetWFStageActionByIdAsync(long actionId);
        Task<List<WorkflowStageActionMaster>> GetAllWFStageAction(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

    }
}

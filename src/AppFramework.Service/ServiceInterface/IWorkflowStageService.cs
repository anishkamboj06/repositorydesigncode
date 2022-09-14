using AppFramework.Domain.ApiModel.WorkflowStage;
using AppFramework.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.ServiceInterface
{
    public interface IWorkflowStageService
    {
        ServiceResult CreateWFStage(AddWorkflowStage model);

        ServiceResult UpdateWFStage(UpdateWorkflowStage model);

        ServiceResult DeleteWFStage(long stageId);

        ServiceResult GetAllWFStage(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        ServiceResult GetWFStageById(long stageId);
    }
}

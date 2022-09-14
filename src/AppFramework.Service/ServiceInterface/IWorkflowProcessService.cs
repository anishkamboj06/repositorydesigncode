using AppFramework.Domain.ApiModel.WorkflowProcess;
using AppFramework.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Service.ServiceInterface
{
    public interface IWorkflowProcessService
    {
        ServiceResult CreateWFProcess(AddWorkflowProcess model);

        ServiceResult UpdateWFProcess(UpdateWorkflowProcess model);

        ServiceResult DeleteWFProcess(int processId);

        ServiceResult GetAllWFProcess(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        ServiceResult GetWFProcessById(int processId);
    }
}

using AppFramework.Domain.ApiModel.Module;
using AppFramework.Domain.ViewModel;

namespace AppFramework.Service.ServiceInterface
{
    public interface IModuleService
    {
        ServiceResult CreateModule(AddModule model);

        ServiceResult UpdateModule(UpdateModule model);

        ServiceResult DeleteModule(int moduleId);

        ServiceResult GetAllModule(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        ServiceResult GetModuleById(int moduleId);

        ServiceResult GetModuleByFeatureId(int featureId);
    }
}

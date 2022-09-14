using AppFramework.Domain.ApiModel.Feature;
using AppFramework.Domain.ViewModel;

namespace AppFramework.Service.ServiceInterface
{
    public interface IFeatureService
    {
        ServiceResult CreateFeature(AddFeature model);

        ServiceResult UpdateFeature(UpdateFeature model);

        ServiceResult DeleteFeature(int featureId);

        ServiceResult GetAllFeature(int pageNumber, int pageSize, string searchKeyword, string sortBy, string sortOrder);

        ServiceResult GetFeatureById(int featureId);
    }
}

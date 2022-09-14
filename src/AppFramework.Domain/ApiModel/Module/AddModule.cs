using System.ComponentModel.DataAnnotations;

namespace AppFramework.Domain.ApiModel.Module
{
    public class AddModule
    {
        [Required(ErrorMessage = "Feature Id is required")]
        public int FeatureId { get; set; }

        [Required(ErrorMessage = "Module title is required")]
        public string ModuleTitle { get; set; }

        public string Description { get; set; }
    }
}

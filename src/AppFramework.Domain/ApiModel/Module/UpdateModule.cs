using System.ComponentModel.DataAnnotations;

namespace AppFramework.Domain.ApiModel.Module
{
    public class UpdateModule
    {
        [Required(ErrorMessage = "Module Id is required")]
        public int ModuleId { get; set; }

        [Required(ErrorMessage = "Feature Id is required")]
        public int FeatureId { get; set; }

        [Required(ErrorMessage = "Module title is required")]
        public string ModuleTitle { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}

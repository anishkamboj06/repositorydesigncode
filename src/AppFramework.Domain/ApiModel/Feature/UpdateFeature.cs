using System.ComponentModel.DataAnnotations;

namespace AppFramework.Domain.ApiModel.Feature
{
    public class UpdateFeature
    {
        [Required(ErrorMessage = "FeatureId is required")]
        public int FeatureId { get; set; }

        [Required(ErrorMessage = "Feature title is required")]
        public string FeatureTitle { get; set; }

        [Required(ErrorMessage = "Short code is required")]
        public string ShortCode { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}

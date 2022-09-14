using System.ComponentModel.DataAnnotations;

namespace AppFramework.Domain.ApiModel.Feature
{
    public class AddFeature
    {
        [Required(ErrorMessage = "Feature title is required")]
        public string FeatureTitle { get; set; }

        [Required(ErrorMessage = "Short code is required")]
        public string ShortCode { get; set; }
    }
}

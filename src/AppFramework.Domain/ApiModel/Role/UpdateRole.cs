using System.ComponentModel.DataAnnotations;

namespace AppFramework.Domain.ApiModel.Role
{
    public class UpdateRole
    {
        [Required(ErrorMessage = "Role Id is required")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role title is required")]
        public string RoleTitle { get; set; }

        [Required]
        public long DepartmentId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public int FeatureId { get; set; }
        [Required]
        public string NavigationIds { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace AppFramework.Domain.ApiModel.Role
{
    public class AddRole
    {
        [Required(ErrorMessage = "Role title is required")]
        public string RoleTitle { get; set; }
        [Required]
        public long DepartmentId { get; set; }
    }
}

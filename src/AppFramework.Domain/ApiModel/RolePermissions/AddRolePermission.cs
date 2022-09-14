using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Domain.ApiModel.RolePermissions
{
    public class AddRolePermission
    {
        [Required(ErrorMessage ="Role is required")]
        public int RoleId { get; set; }
        
        [Required(ErrorMessage = "Feature is required")]
        public int FeatureId { get; set; }
        
        [Required(ErrorMessage = "Module is required")]
        public int ModuleId { get; set; }
        
        [Required]
        public bool CanCreate { get; set; }
        
        [Required]
        public bool CanRead { get; set; }
        
        [Required]
        public bool CanUpdate { get; set; }
        
        [Required]
        public bool CanDelete { get; set; }
    }
}

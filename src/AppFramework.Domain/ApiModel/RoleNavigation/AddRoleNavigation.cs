using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppFramework.Domain.ApiModel.RoleNavigation
{
    public class AddRoleNavigation
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int FeatureId { get; set; }
        [Required]
        public int NavigationId { get; set; }
        [Required]
        public long DepartmentId { get; set; }

        [JsonIgnore]    
        public string RoleTitle { get; set; }
    }
}

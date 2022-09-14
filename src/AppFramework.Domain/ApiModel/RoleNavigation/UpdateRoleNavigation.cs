using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Domain.ApiModel.RoleNavigation
{
    public class UpdateRoleNavigation
    {
        [Required]
        public int MappingId { get; set; }
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int FeatureId { get; set; }
        [Required]
        public int NavigationId { get; set; }

    }
}

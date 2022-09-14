using AppFramework.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Domain.ApiModel.Role
{
    public  class RoleNavigationMapping
    {
        public int RoleId { get; set; }
        public string RoleTitle { get; set; }
        public int FeatureId { get; set; }
        public long DepartmentId { get; set; }
        public List<Navigations> NavList { get; set; }
    }

    public class Navigations
    {
        public int NavigationIds { get; set; }
    }
    
}

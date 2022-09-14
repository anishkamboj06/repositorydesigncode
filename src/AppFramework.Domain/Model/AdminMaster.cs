using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Domain.Model
{
    public class AdminMaster
    {
        public int EmployeeID { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeptAdmin { get; set; }
        public string Token { get; set; }
        public string ImageCode { get; set; }
        [IgnoreDataMember]
        public string ImageReference { get; set; }
    }
}

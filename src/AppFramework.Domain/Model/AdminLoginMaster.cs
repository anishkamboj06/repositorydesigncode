using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Domain.Model
{
    public class AdminLoginMaster
    {
        public String Email { get; set; }
        public String UserPassword { get; set; }
    }
}

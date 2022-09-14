using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Domain.Model
{
    public class StateMaster
    {
        public string StateName { get; set; }
        public long LGDCode { get; set; }
        public bool IsActive { get; set; }
    }
}

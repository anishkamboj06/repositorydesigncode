using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Domain.Model
{
    public class LogMaster
    {
        public int Id { get; set; }
        public string FunctionName { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public long StatusCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

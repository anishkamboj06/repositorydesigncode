using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppFramework.Domain.ApiModel.Relieving
{
    public class AddRelieving
    {
        [JsonIgnore]
        public long EmployeeId { get; set; }
        [Required]
        public long DepartmentId { get; set; }
        [Required]
        public DateTime RelievingDate { get; set; }
        public long SerialNumber { get; set; }

    }
}

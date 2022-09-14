using System;
using System.Runtime.Serialization;

namespace AppFramework.Domain.Model
{
    public class RoleMaster
    {
        public int RoleId { get; set; }
        public string RoleTitle { get; set; }
        public bool? IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long DepartmentId { get; set; }
        [IgnoreDataMember]
        public long PageNumber { get; set; }
        [IgnoreDataMember]
        public long PageSize { get; set; }
        [IgnoreDataMember]
        public string SearchKeyword { get; set; }
        [IgnoreDataMember]
        public string SortBy { get; set; }
        [IgnoreDataMember]
        public string SortOrder { get; set; }
        public int TotalCount { get; set; }

        public int FeatureId { get; set; }
      
        public string NavigationIds { get; set; }
    }
}

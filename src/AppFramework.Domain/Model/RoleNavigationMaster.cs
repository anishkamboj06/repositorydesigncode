﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AppFramework.Domain.Model
{
    public class RoleNavigationMaster
    {
        public int MappingId { get; set; }
        public int RoleId { get; set; }
        public int FeatureId { get; set; }
        public int NavigationId { get; set; }
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
    }    
}

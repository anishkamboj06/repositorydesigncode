﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AppFramework.Domain.Model;
using System.Text.Json.Serialization;
using System.Data;

namespace AppFramework.Domain.ApiModel.Navigation
{
   public class UpdateNavigation
    {
        [Required(ErrorMessage = "Navigation Id is required")]

        public int NavigationId { get; set; }

        [Required(ErrorMessage = "Feature is Required")]
        public int FeatureId { get; set; }
        [Required]
        public long DepartmentId { get; set; }
        [Required(ErrorMessage = "Navigation Title is Required")]
        public string NavigationTitle { get; set; }
        [Required(ErrorMessage = "Navigation Url is Required")]
        public string NavigationUrl { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string NavigationDescription { get; set; }
        public int NavigationPosition { get; set; }
        public int ParentNavigationId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }

}

   

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppFramework.Domain.ApiModel.Profile
{
    public class UpdateProfileImage
    {
        [Required]
        public long Id { get; set; }
        [JsonIgnore]
        public string ImageFile { get; set; }
        [Required]
        public string ImageCode { get; set; }
        [JsonIgnore]
        public string ImageReference { get; set; }
    }
}

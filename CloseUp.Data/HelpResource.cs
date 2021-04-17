﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Data
{
    public class HelpResource
    {
        [Key]
        [Display(Name = "ID")]
        public int ResourceId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Information")]
        public string ResourceInfo { get; set; }
    }
}

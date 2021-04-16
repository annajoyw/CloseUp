using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models
{
    public class ResourceCreate
    {
        [Required]
        public string Category { get; set; }

        [Required]
        public string ResourceInfo { get; set; }
    }
}

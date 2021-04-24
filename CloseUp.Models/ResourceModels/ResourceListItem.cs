using CloseUp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models
{
    public class ResourceListItem
    {
        public int ResourceId { get; set; }

        public Tag Tag { get; set; }

        public string ResourceInfo { get; set; }
    }
}

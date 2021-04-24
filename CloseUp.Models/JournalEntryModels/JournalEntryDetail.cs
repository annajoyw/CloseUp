using CloseUp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models
{
    public class JournalEntryDetail
    {
        public int JournalEntryId { get; set; }
        public string Prompt { get; set; }

        public string Content { get; set; }

        [Display(Name = "Photo URL(optional)")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Public")]
        public bool IsPublic { get; set; }

        public Tag Tag { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

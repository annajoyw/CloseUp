using CloseUp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models
{
    public class JournalEntryListItem
    {
        public int JournalEntryId { get; set; }


        [Display(Name = "Prompt")]
        public string Prompt { get; set; }


        public string Content { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }


        [Display(Name = "Public Post")]
        public bool IsPublic { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

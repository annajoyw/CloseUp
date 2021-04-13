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
        public int EntryId { get; set; }
        public int PromptId { get; set; }

        public string Content { get; set; }

        [Display(Name = "Photo URL(optional)")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Public")]
        public bool IsPublic { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

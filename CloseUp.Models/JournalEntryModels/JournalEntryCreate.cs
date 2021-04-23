using CloseUp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models
{
    public class JournalEntryCreate
    {
        public int PromptId { get; set; }

        [Required]
        [Display(Name = "Prompt")]
        public string Prompt { get;  }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Photo URL(optional)")]
        public string PhotoUrl { get; set; }

        [Required]
        [Display(Name = "Make this entry public")]
        public bool IsPublic { get; set; }

        public virtual PromptItem PromptItem { get; set; }


    }
}

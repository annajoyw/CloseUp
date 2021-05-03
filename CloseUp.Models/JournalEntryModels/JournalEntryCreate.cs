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
        public string Content { get; set; }

        [Display(Name = "Photo URL(optional)")]
        public string PhotoUrl { get; set; }

        [Display(Name = "Make this entry public")]
        public PublicOrPrivate PublicOrPrivate { get; set; }

        public Tag Tag { get; set; }


    }
}

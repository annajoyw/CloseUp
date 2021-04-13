using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Data
{
   public class JournalEntry
    {
        [Key]
        public int JournalEntryId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }

        [Required]
        [Display(Name = "Public Post")]
        public bool IsPublic { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey("PromptItem")]
        public int PromptId { get; set; }
        public virtual PromptItem PromptItem { get; set; }

        //Reply here?
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Data
{
    public class PromptItem
    {
        [Key]
        public int PromptId { get; set; }

        [Required]
        public string Prompt { get; set; }

        [ForeignKey("JournalEntry")]
        public int JournalEntryId { get; set; }
        public virtual JournalEntry JournalEntry { get; set; }

        
    }
}

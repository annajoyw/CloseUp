using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //user has option to choose prompt or write their own
        public List<string> Prompt { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }

        [Required]
        [Display(Name = "Public Post")]
        public bool IsPublic { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Data
{
    class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Comment { get; set; }

        [ForeignKey("JournalEntry")]
        public int JournalEntryId { get; set; }
        public virtual JournalEntry JournalEntry { get; set; }

    }
}

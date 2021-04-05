using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Data
{
    class JournalEntry
    {
        [Key]
        public int  EntryId{ get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsPublic { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        //fk to reply
    }
}

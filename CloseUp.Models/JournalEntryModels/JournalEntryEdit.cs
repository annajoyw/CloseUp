using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models
{
    public class JournalEntryEdit
    {
        public int JournalEntryId { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsPublic { get; set; }

    }
}

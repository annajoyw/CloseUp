using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models
{
    public class ReplyCreate
    {
        public int JournalEntryId { get; set; }

        public string Comment { get; set; }
    }
}

using CloseUp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models.JournalEntryModels
{
    public class PromptedEntryCreate
    {
        public int PromptId { get; set; }
        public string Prompt { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public PublicOrPrivate PublicOrPrivate { get; set; }
        public Tag Tag { get; set; }
    }
}

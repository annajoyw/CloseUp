using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}

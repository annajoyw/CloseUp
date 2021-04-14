using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Models
{
    public class PromptCreate
    {
        [Required]
        public string Prompt { get; set; }
    }
}

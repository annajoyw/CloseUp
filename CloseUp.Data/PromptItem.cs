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
        //possibly add category prop here , so we can match prompt to resources
        //give enum of different types of prompts?
        [Key]
        public int PromptId { get; set; }

        [Required]
        public string Prompt { get; set; }        
    }
}

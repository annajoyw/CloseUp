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
        //add another data table for requests? or can that be something that isnt back end..... make a box that says "send an email!"
        [Key]
        public int PromptId { get; set; }

        public string Category { get; set; }

        [Required]
        public string Prompt { get; set; }        
    }
}

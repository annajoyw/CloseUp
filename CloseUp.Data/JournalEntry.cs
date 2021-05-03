using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Data
{
    public enum Tag
    {
        None = 1 ,
        Mindfulness,
        [Display(Name = "Health and Wellness")]
        HealthAndWellness,
        [Display(Name = "LGBT+")]
        LGBT,
        BLM,
        [Display(Name = "Anxiety and Depression")]
        AnxietyAndDepression,
        [Display(Name = "ADHD and ASD")]
        AdhdAndAutism,
        [Display(Name = "Substance Abuse")]
        SubstanceAbuse,
        [Display(Name = "Help Hotlines")]
        Hotline,
        Other
    }

    public enum PublicOrPrivate
    {
        Public,
        Private
    }
    public class JournalEntry
    {
        [Key]
        public int JournalEntryId { get; set; }

        [Required]
        public Guid UserId { get; set; }


        public string Prompt { get; set; }

        [Required]
        public string Content { get; set; }

        [Display(Name = "Photo")]
        public string PhotoUrl { get; set; }

        [Required]
        [Display(Name = "Public Post")]
        public PublicOrPrivate PublicOrPrivate { get; set; } = new PublicOrPrivate();

        public Tag Tag { get; set; } = new Tag();

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey("PromptItem")]
        public int PromptId { get; set; }
        public virtual PromptItem PromptItem { get; set; }

        //Reply here?
    }
}

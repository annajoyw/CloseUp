using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Data
{
    class SeededPromptData : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed (ApplicationDbContext ctx)
        {
            IList<PromptItem> defaultPrompts = new List<PromptItem>();

            defaultPrompts.Add(new PromptItem() { PromptId = 1, Prompt = "What is something you wish more people knew about you?" });
            defaultPrompts.Add(new PromptItem() { PromptId = 2, Prompt = "Write the words you need to hear." });
            defaultPrompts.Add(new PromptItem() { PromptId = 3, Prompt = "What would make you feel spiritually fufilled?" });
            defaultPrompts.Add(new PromptItem() { PromptId = 4, Prompt = "Write or post a photo of what you love most." });
            defaultPrompts.Add(new PromptItem() { PromptId = 5, Prompt = "What brings you comfort?" });
            defaultPrompts.Add(new PromptItem() { PromptId = 6, Prompt = "How are you? Really" });

            ctx.Prompts.AddRange(defaultPrompts);

            base.Seed(ctx);
        }
     
    }
}

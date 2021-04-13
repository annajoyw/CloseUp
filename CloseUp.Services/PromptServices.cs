using CloseUp.Data;
using CloseUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Services
{
    public class PromptServices
    {
        //add admin authentication here?

        //private readonly Guid _userId;

        //public PromptServices(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreatePrompt(PromptCreate model)
        {
            var entity =
                new PromptItem()
                {
                    Prompt = model.Prompt
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Prompts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PromptListItem> GetPrompts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Prompts
                    .Select(
                        x =>
                        new PromptListItem
                        {
                            Prompt = x.Prompt
                        }
                        );
                return query.ToArray();
            }
        }
    }
}

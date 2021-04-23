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
                    Category = model.Category,
                    Prompt = model.Prompt
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PromptItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PromptListItem> GetPrompts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.PromptItems
                    .Select(
                        x =>
                        new PromptListItem
                        {
                            PromptId = x.PromptId,
                            Category = x.Category,
                            Prompt = x.Prompt
                        }
                        );
                return query.ToArray();
            }
        }

        public PromptDetail GetPromptById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PromptItems
                    .Single(x => x.PromptId == id);
                return
                    new PromptDetail
                    {
                        Prompt = entity.Prompt,
                    };
            }
        }

        public bool UpdatePrompt(PromptEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .PromptItems
                    .Single(x => x.PromptId == model.PromptId);

                entity.Prompt = model.Prompt;
                entity.Category = model.Category;

                return ctx.SaveChanges() == 1;
            }
        }


    }
}

using CloseUp.Data;
using CloseUp.Models;
using CloseUp.Models.JournalEntryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Services
{
    public class JournalEntryServices
    {
        private readonly Guid _userId;

        public JournalEntryServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateEntry(JournalEntryCreate model)
        {

            var entity =
                new JournalEntry()
                {
                    UserId = _userId,
                    PromptId = model.PromptId,
                    Content = model.Content,
                    PhotoUrl = model.PhotoUrl,
                    IsPublic = model.IsPublic,
                    Tag = model.Tag,
                    CreatedUtc = DateTimeOffset.Now
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.JournalEntries.Add(entity);
                    return ctx.SaveChanges() == 1;
                }

        }

        
            //public string SelectPrompt(string prompt)
            //{
            //    using (var ctx = new ApplicationDbContext())
            //    {
            //        var entity =
            //            ctx
            //            .Prompts
            //            .Select(x => x.Prompt == prompt);

            //        return new SelectPrompt

            //    }
            //}

            public IEnumerable<JournalEntryListItem> GetEntries()
            {

                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                        .JournalEntries
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                            new JournalEntryListItem
                            {
                                JournalEntryId = e.JournalEntryId,
                                Prompt = e.PromptItem.Prompt,
                                Content = e.Content,
                                PhotoUrl = e.PhotoUrl,
                                IsPublic = e.IsPublic,
                                CreatedUtc = e.CreatedUtc
                            }
                            );
                    return query.ToArray();
                }
            }

            public JournalEntryDetail GetEntryById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx.JournalEntries
                        .Single(x => x.JournalEntryId == id && x.UserId == _userId);
                    return
                        new JournalEntryDetail
                        {
                            JournalEntryId = entity.JournalEntryId,
                            Prompt = entity.PromptItem.Prompt,
                            Content = entity.Content,
                            PhotoUrl = entity.PhotoUrl,
                            IsPublic = entity.IsPublic,
                        };
                }
            }

            public bool UpdateEntry(JournalEntryEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .JournalEntries
                        .Single(x => x.JournalEntryId == model.JournalEntryId && x.UserId == _userId);

                    entity.Content = model.Content;
                    entity.PhotoUrl = model.PhotoUrl;
                    entity.IsPublic = model.IsPublic;
                    entity.Tag = model.Tag;

                    return ctx.SaveChanges() == 1;
                }
            }

            public bool DeleteEntry(int entryId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .JournalEntries
                        .Single(x => x.JournalEntryId == entryId && x.UserId == _userId);

                    ctx.JournalEntries.Remove(entity);

                    return ctx.SaveChanges() == 1;
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

        }
    }



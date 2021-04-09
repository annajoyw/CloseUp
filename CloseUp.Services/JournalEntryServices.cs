using CloseUp.Data;
using CloseUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Prompt = model.Prompt,
                    Content = model.Content,
                    PhotoUrl = model.PhotoUrl,
                    IsPublic = model.IsPublic,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.JournalEntries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

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


                        }
                        )
            }
        }
    }
}

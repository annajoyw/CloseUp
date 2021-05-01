using CloseUp.Data;
using CloseUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Services
{
    public class PublicPostServices
    {
        public IEnumerable<JournalEntryListItem> GetPublicPosts(bool isPublic)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .JournalEntries
                    .Where(x => x.IsPublic == isPublic)
                    .Select(
                         x => new JournalEntryListItem
                         {
                             
                             Tag = x.Tag,
                             Prompt = x.Prompt,
                             Content = x.Content,
                             PhotoUrl = x.PhotoUrl,
                             CreatedUtc = x.CreatedUtc
                         }
                        );
                return query.ToArray();

            }
        }
    }
}

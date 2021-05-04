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
        public IEnumerable<JournalEntryListItem> GetPublicPosts(PublicOrPrivate publicPost)
        {
            
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .JournalEntries
                    .Where(x => x.PublicOrPrivate == publicPost)
                    .Select(
                         x => new JournalEntryListItem
                         {
                             
                             Tag = x.Tag,
                             Prompt = x.PromptItem.Prompt,
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

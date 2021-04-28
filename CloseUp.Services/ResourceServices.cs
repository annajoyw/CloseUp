using CloseUp.Data;
using CloseUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Services
{
    public class ResourceServices
    {
        public bool CreateResource(ResourceCreate model)
        {
            var entity =
                new HelpResource()
                {
                    Tag = model.Tag,
                    ResourceInfo = model.ResourceInfo
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.HelpResources.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ResourceListItem> GetResources()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .HelpResources
                    .Select(
                        x => new ResourceListItem
                        {
                            ResourceId = x.ResourceId,
                            Tag = x.Tag,
                            ResourceInfo = x.ResourceInfo
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ResourceListItem> GetResourcesByTag(Tag tag)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .HelpResources
                    .Where(x=> x.Tag == tag)
                    .Select(
                         x => new ResourceListItem
                         {
                             ResourceId = x.ResourceId,
                             Tag = x.Tag,
                             ResourceInfo = x.ResourceInfo
                         }
                        );
                return query.ToArray();

            }
        }

        public ResourceDetail GetResourceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .HelpResources
                    .Single(x => x.ResourceId == id);
                return
                    new ResourceDetail
                    {
                        ResourceId = entity.ResourceId,
                        Tag = entity.Tag,
                        ResourceInfo = entity.ResourceInfo
                    };
            }
        }

        public bool UpdateResource(ResourceEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .HelpResources
                    .Single(x => x.ResourceId == model.ResourceId);
                entity.Tag = model.Tag;
                entity.ResourceInfo = model.ResourceInfo;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteResource(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .HelpResources
                    .Single(x => x.ResourceId == id);

                ctx.HelpResources.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

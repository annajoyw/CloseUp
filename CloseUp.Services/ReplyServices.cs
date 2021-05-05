using CloseUp.Data;
using CloseUp.Models;
using CloseUp.Models.ReplyModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseUp.Services
{
    public class ReplyServices
    {
        private readonly Guid _userId;

        public ReplyServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {

            var entity =
                new Reply()
                {
                    UserId = _userId,
                    JournalEntryId = model.JournalEntryId,
                    Comment = model.Comment
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<ReplyListItem> GetEntryReplies(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.JournalEntryId == id)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            Comment = e.Comment
                        }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                          Comment = e.Comment
                        }
                        );
                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(x => x.ReplyId == id);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.ReplyId,
                        Comment = entity.Comment
                    };
            }
        }

        public bool DeleteReply(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(x => x.ReplyId == replyId && x.UserId == _userId);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(x => x.ReplyId == model.ReplyId && x.UserId == _userId);

                entity.Comment = model.Comment;

             
                return ctx.SaveChanges() == 1;
            }
        }

    }
}

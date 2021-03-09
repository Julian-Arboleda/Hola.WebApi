using Hola.Data;
using Hola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Services
{
    public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    CreatorId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    DateCreated = model.DateCreated
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MessageListItem> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.CreatorId == _userId)
                        .Select(
                            e =>
                                new MessageListItem
                                {
                                    Title = e.Title,
                                    MessageId = e.MessageId,
                                    Content = e.Content,
                                    DateCreated = e.DateCreated
                                }
                        );

                return query.ToArray();
            }
        }

        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == id && e.CreatorId == _userId);
                return
                    new MessageDetail
                    {
                        Title = entity.Title,
                        MessageId = entity.MessageId,
                        Content = entity.Content,
                        DateCreated = entity.DateCreated,
                        ModifiedDateCreated = entity.ModifiedDateCreated
                    };
            }
        }

        public bool UpdateMessage(MessageEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == model.MessageId && e.CreatorId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedDateCreated = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMessage(int messageId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == messageId && e.CreatorId == _userId);

                ctx.Messages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
using Hola.Data;
using Hola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Services
{
    public class EventMessageService
    {
        private readonly Guid _userId;

        public EventMessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEventMessage(EventMessageCreate model)
        {
            var entity =
                new EventMessage()
                {
                    EventId = model.EventId,
                    CreatorId = _userId,
                    Content = model.Content,
                    DateCreated = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.EventMessages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventMessageListItem> GetEventMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .EventMessages
                        .Where(e => e.CreatorId == _userId)
                        .Select(
                            e =>
                                new EventMessageListItem
                                {
                                    EventMessageId = e.EventMessageId,
                                    Content = e.Content,
                                    DateCreated = e.DateCreated
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

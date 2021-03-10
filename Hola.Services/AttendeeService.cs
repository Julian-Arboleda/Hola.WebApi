using Hola.Data;
using Hola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Services
{
    public class AttendeeService
    {
        private readonly Guid _userId;

        public AttendeeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAttendee(AttendeeCreate model)
        {
            var entity =
                new Attendee()
                {
                    CreatorId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    EventId = model.EventId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attendees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AttendeeListItem> GetAttendees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Attendees
                        .Where(e => e.CreatorId == _userId)
                        .Select(
                            e =>
                                new AttendeeListItem
                                {
                                    AttendeeId = e.AttendeeId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    EventId = e.EventId
                                }
                        );

                return query.ToArray();
            }
        }

        //Update
        public bool UpdateAttendee(AttendeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Attendees
                    .Single(e => e.EventId == model.EventId && e.AttendeeId == model.AttendeeId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.EventId = model.EventId;
                entity.AttendeeId = model.AttendeeId;
              

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete

        public bool DeleteAttendee(int AttendeeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Attendees
                    .Single(e => e.AttendeeId == AttendeeId && e.CreatorId == _userId);
                ctx.Attendees.Remove(entity);
                    return ctx.SaveChanges() == 1;
            }
        }

    }
}

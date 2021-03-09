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
        public bool CreateAttendee(AttendeeCreate Model)
        {
            var entity =
                new Attendee()
                {
                    CreatorId = _userId,
                    FirstName = Model.FirstName,
                    LastName = Model.LastName,
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
                                    LastName = e.LastName
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

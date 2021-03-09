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
        public bool createAttendee(AttendeeCreate Model)
        {
            var entity =
                new Attendee()
                {
                    AttendeeId = Model.AttendeeID,
                    FirstName = Model.FirstName,
                    LastName = Model.LastName,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attendee.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

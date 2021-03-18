using Hola.Data;
using Hola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    HostId = _userId,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreated = model.DateCreated,
                    LocationId = model.LocationId,
                    IsLiked = model.IsLiked,
                    Host = model.Host

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.HostId == _userId)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    Name = e.Name,
                                    DateCreated = e.DateCreated,
                                    LocationId = e.LocationId,
                                    IsLiked = e.IsLiked,
                                    Description = e.Description,
                                    Host = e.Host
                                }
                        );

                return query.ToArray();
            }
        }

        public EventDetail GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .SingleOrDefault(e => e.EventId == id && e.HostId == _userId);
                return

                    new EventDetail
                    {
                        EventId = entity.EventId,
                        Name = entity.Name,
                        Description = entity.Description,
                        DateCreated = entity.DateCreated,
                        ModifiedDateCreated = entity.ModifiedDateCreated,
                        IsLiked = entity.IsLiked,
                        Host = entity.Host
                    };




            }


        }






        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == model.EventId && e.HostId == _userId);
                entity.EventId = model.EventId;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.IsLiked = model.IsLiked;
                entity.DateCreated = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }

        }

        public bool DeleteEvent(int eventid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == eventid && e.HostId == _userId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<EventListItem> GetEventsByLocationId(int locationid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.HostId == _userId && e.LocationId == locationid)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    Name = e.Name,
                                    DateCreated = e.DateCreated,
                                    LocationId = e.LocationId,
                                    IsLiked = e.IsLiked

                                }
                        );

                return query.ToArray();
            }
        }
    }
}




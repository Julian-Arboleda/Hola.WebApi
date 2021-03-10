using Hola.Data;
using Hola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hola.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    CreatorId = _userId,
                    Name = model.Name,
                    Country = model.Country,
                    State = model.State,
                    City = model.City,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Where(e => e.CreatorId == _userId)
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    LocationId = e.LocationId,
                                    Name = e.Name,
                                    Country = e.Country,
                                    State = e.State,
                                    City = e.City
                                }
                        );

                return query.ToArray();
            }
        }     


        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var updatedlocation =
                    ctx
                    .Locations
                    .Single(e => e.LocationId == model.LocationId && e.CreatorId == _userId);
                updatedlocation.LocationId = model.LocationId;          
                updatedlocation.Country = model.Country;
                updatedlocation.State = model.State;
                updatedlocation.City = model.City;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationId)
        {
            using (var ctx =  new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationId == locationId && e.CreatorId == _userId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}

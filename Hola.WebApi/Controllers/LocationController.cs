using Hola.Models;
using Hola.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hola.WebApi.Controllers
{
    public class LocationController : ApiController
    {
        [Authorize]
        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var locationService = new LocationService(userId);
            return locationService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            LocationService locationService = CreateLocationService();
            var locations = locationService.GetLocations();
            return Ok(locations);
        }

        [HttpPost]
        public IHttpActionResult PostLocation(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();

            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid Location");

            var service = CreateLocationService();

            if (!service.UpdateLocation(location))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateLocationService();
            if (!service.DeleteLocation(id))
            return InternalServerError();

            return Ok();

        }
    }
}

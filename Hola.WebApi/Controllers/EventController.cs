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
    public class EventController : ApiController
    {
        [Authorize]
        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var eventService = new EventService(userId);
            return eventService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            EventService eventService = CreateEventService();
            var events = eventService.GetEvents();
            return Ok(events);
        }

        [HttpPost]
        public IHttpActionResult CreateEvent(EventCreate eventCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEventService();

            if (!service.CreateEvent(eventCreate))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(EventEdit eventupdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEventService();

            if (!service.UpdateEvent(eventupdate))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateEventService();

            if (!service.DeleteEvent(id))
                return InternalServerError();

            return Ok();
        }

    }   
}

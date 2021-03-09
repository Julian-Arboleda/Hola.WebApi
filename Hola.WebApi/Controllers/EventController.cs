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
        public IHttpActionResult PostEvent(EventCreate event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.CreateNote(note))
                return InternalServerError();

            return Ok();
        }
    }   
}

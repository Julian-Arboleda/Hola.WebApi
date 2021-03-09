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
    }
}

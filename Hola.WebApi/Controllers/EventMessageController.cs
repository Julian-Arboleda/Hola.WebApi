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
    [Authorize]
    public class EventMessageController : ApiController
    {
        private EventMessageService CreateEventMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var eventMessageService = new EventMessageService(userId);
            return eventMessageService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            EventMessageService eventMessageService = CreateEventMessageService();
            var eventMessage = eventMessageService.GetEventMessages();
            return Ok(eventMessage);
        }

        [HttpPost]
        public IHttpActionResult Post(EventMessageCreate eventMessage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEventMessageService();

            if (!service.CreateEventMessage(eventMessage))
                return InternalServerError();

            return Ok();
        }
    }
}


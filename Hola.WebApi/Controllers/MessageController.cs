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
    public class MessageController : ApiController
    {
        [Authorize]
        private MessageService CreateMessageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var messageService = new MessageService(userId);
            return messageService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            MessageService messageService = CreateMessageService();
            var messages = messageService.GetMessages();
            return Ok(messages);
        }

        [HttpPost]
        public IHttpActionResult PostMessage(MessageCreate message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMessageService();

            if (!service.CreateMessage(message))
                return InternalServerError();

            return Ok();
        }
    }
}

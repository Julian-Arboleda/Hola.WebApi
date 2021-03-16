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

        [HttpGet]
        public IHttpActionResult GetMessage(int id)
        {
            MessageService messageService = CreateMessageService();
            var message = messageService.GetMessageById(id);
            return Ok(message);
        }

        [HttpPut]
        public IHttpActionResult Put(MessageEdit message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMessageService();

            if (!service.UpdateMessage(message))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateMessageService();

            if (!service.DeleteMessage(id))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        [Route("{id}/ Like")]
        public bool Like(int id)
        {
            var service = CreateMessageService();

            var detail = service.GetMessageById(id);

            var updatedMessage =
                new MessageEdit
                {
                    MessageId = detail.MessageId,
                    Content = detail.Content,
                    IsLiked = detail.IsLiked
                };

            return service.UpdateMessage(updatedMessage);
        }
    }
}

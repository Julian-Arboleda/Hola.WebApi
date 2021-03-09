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
    public class AttendeeController : ApiController
    {
        [Authorize]
        private AttendeeService CreateAttendeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var attendeeService = new AttendeeService(userId);
            return attendeeService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            AttendeeService attendeeService = CreateAttendeeService();
            var attendees = attendeeService.GetAttendees();
            return Ok(attendees);
        }

        //Update Attendee
        public IHttpActionResult Put(AttendeeEdit attendee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAttendeeService();
            if (!service.UpdateAttendee(attendee))
                return InternalServerError();
            return Ok();
        }

        //DeleteAttendee

        public IHttpActionResult Delete(int id)
        {
            var service = CreateAttendeeService();
            if (!service.DeleteAttendee(id))
                return InternalServerError();
            return Ok();
        }

    }
}

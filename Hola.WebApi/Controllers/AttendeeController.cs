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
    }

    [HttpGet]
    public IHttpActionResult Get()
    {
        AttendeeService attendeeService = CreateAttendeeService();
        var attendees = attendeeService.GetAttendee();
        return Ok(attendees);
    }
}

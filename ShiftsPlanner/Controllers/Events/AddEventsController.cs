using ShiftsPlanner.Models;
using ShiftsPlanner.Models.DataAccessLayer;
using ShiftsPlanner.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShiftsPlanner.Controllers.Shifts
{
    [RoutePrefix("api/events")]
    public class AddEventsController : ApiController
    {
        [HttpGet]
        [Route("get/addEvents")]

        public HttpResponseMessage GetAddedEvents(HttpRequestMessage request)
        {
            var db = new ShiftsPlannerContext();

            var events = db.Events.Select(x => new { x.EventID, x.Date, x.Location, x.Shifts }).ToList().Select(y => new EventDTO()
            {
                EventID = y.EventID,
                Date = y.Date.ToShortDateString(),
                Location = y.Location,
                Shifts = y.Shifts.ToList()

            }).ToList();
                             

            return request.CreateResponse(HttpStatusCode.OK, events);
        }

        [HttpPost]
        [Route("add/addEvents")]

        public HttpResponseMessage AddEvents(HttpRequestMessage request, [FromBody] EventDTO eventDTO)
        {
            var db = new ShiftsPlannerContext();

            var test = DateTime.Parse(eventDTO.Date);

            var myEvent = new Event
            {
                EventID = Guid.NewGuid(),
                Date = DateTime.Parse(eventDTO.Date),
                Location = eventDTO.Location,
                Shifts = eventDTO.Shifts
                
            };

            foreach (var item in myEvent.Shifts)
            {
                item.ShiftID = Guid.NewGuid();
            }

            db.Events.Add(myEvent);

            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, myEvent);
        }

       

    }
}

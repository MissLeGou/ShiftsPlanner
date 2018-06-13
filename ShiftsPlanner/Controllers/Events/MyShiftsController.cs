using ShiftsPlanner.Models.DataAccessLayer;
using ShiftsPlanner.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShiftsPlanner.Controllers.Events
{
    [RoutePrefix("api/events")]
    public class MyShiftsController : ApiController
    {
        [HttpGet]
        [Route("get/myShifts")]

        public HttpResponseMessage GetMyShifts(HttpRequestMessage request)
        {
            var db = new ShiftsPlannerContext();

            var myShifts = db.Shifts.Select(x => new { x.ShiftID, x.Event.Date, x.ShiftTime, x.Event.Location }).ToList().Select(y => new MyShiftDTO()
            {
                ShiftID = y.ShiftID,
                Date = y.Date.ToShortDateString(),
                Time = y.ShiftTime,
                Location = y.Location,

            }).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, myShifts);
        }

        [HttpPost]
        [Route("delete/myShifts")]

        public HttpResponseMessage DeleteMyShifts(HttpRequestMessage request, [FromBody] MyShiftDTO myShiftDTO)
        {
            var db = new ShiftsPlannerContext();

            var selectedMyShift = db.Shifts.Find(myShiftDTO.ShiftID);
            var selectedEvent = selectedMyShift.Event;

            db.Shifts.RemoveRange(selectedEvent.Shifts);


            if (selectedEvent != null) db.Events.Remove(selectedEvent);

            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "success");
        }

    }
}

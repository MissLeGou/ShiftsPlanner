using ShiftsPlanner.Models;
using ShiftsPlanner.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShiftsPlanner.Controllers.Shifts
{
    [RoutePrefix("api/shifts")]
    public class AddShiftsController : ApiController
    {
        [HttpGet]
        [Route("get/addShifts")]

        public HttpResponseMessage GetAddedShifts(HttpRequestMessage request)
        {
            var db = new ShiftsPlannerContext();

            var shifts = db.Shifts.Select(x => new { x.ShiftID, x.Location, x.Date, x.StartTime, x.EndTime }).ToList().Select(y => new Shift()
            {
                ShiftID = y.ShiftID,
                Location = y.Location,
                Date = y.Date,
                StartTime = y.StartTime,
                EndTime = y.EndTime

            }).ToList();
                             

            return request.CreateResponse(HttpStatusCode.OK, shifts);
        }

        [HttpPost]
        [Route("add/addShifts")]

        public HttpResponseMessage AddShifts(HttpRequestMessage request, [FromBody] Shift shift)
        {
            var db = new ShiftsPlannerContext();

            var myShift = new Shift
            {
                ShiftID = shift.ShiftID,
                Location = shift.Location,
                Date = shift.Date,
                StartTime = shift.StartTime,
                EndTime = shift.EndTime

            };
            db.Shifts.Add(myShift);

            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, myShift);
        }

        [HttpPost]
        [Route("delete/addShifts")]

        public HttpResponseMessage DeleteShifts(HttpRequestMessage request, [FromBody] Shift shift)
        {
            var db = new ShiftsPlannerContext();

            var selectedShift = db.Shifts.Find(shift.ShiftID);

            if (selectedShift != null) db.Shifts.Remove(selectedShift);

            db.SaveChanges();


            return request.CreateResponse(HttpStatusCode.OK, "success");
        }

    }
}

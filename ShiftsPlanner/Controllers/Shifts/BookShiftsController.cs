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
    [RoutePrefix("api/shifts")]
    public class BookShiftsController : ApiController
    {
        [HttpGet]
        [Route("get/bookedShifts")]

        public HttpResponseMessage GetBookedShifts(HttpRequestMessage request)
        {
            var db = new ShiftsPlannerContext();

            var queryString = Request.GetQueryNameValuePairs();

            var shiftOnDay = db.Shifts.Select(x => new { x.ShiftID, x.Event.Date, x.ShiftTime, x.Event.Location }).ToList().Select(y => new MyShiftDTO()
            {
                ShiftID = y.ShiftID,
                Date = y.Date.ToShortDateString(),
                Time = y.ShiftTime,
                Location = y.Location
                

            }).Where(x => x.Date == (queryString.First().Value)).ToList();

            return request.CreateResponse(HttpStatusCode.OK, shiftOnDay);
        }

        [HttpPost]
        [Route("add/addBookingShift")]

        public HttpResponseMessage AddBookingShift(HttpRequestMessage request, [FromBody] BookingDTO bookingDTO)
        {
            var db = new ShiftsPlannerContext();

            var myBooking = new Booking
            {
              BookingID = Guid.NewGuid(),
              ShiftID = bookingDTO.ShiftID,
              UserName = bookingDTO.UserName,
                             
            };

            db.Bookings.Add(myBooking);

            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, myBooking);
        }

        [HttpPost]
        [Route("delete/addBookingShift")]

        public HttpResponseMessage DeleteAddBookingShift(HttpRequestMessage request, [FromBody] BookingDTO booking)
        {
            var db = new ShiftsPlannerContext();

            var selectedBooking = db.Bookings.Find(booking.BookingID);

            if (selectedBooking != null) db.Bookings.Remove(selectedBooking);

            db.SaveChanges();

            return request.CreateResponse(HttpStatusCode.OK, "success");
        }
    }
}

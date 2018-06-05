using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShiftsPlanner.Controllers
{
    //[Authorize]
    [RoutePrefix("api/calendar")]
    public class CalendarController : ApiController
    {

        public struct dayObject
        {
            public int week { get; set; }
            public int day { get; set; }
            public DayOfWeek DayOfWeek { get; set; }
            public string TimeStamp { get; set; }
          
        }
        
        public List<dayObject> AllDatesInAMonth(int year, int month)
        {
            var firstOftargetMonth = new DateTime(year, month, 1);
            var firstOfNextMonth = firstOftargetMonth.AddMonths(1);
            var allDates = new List<dayObject>();
            var week = 0;
            var thisDay = firstOftargetMonth;
          
            while (thisDay.DayOfWeek != 0)
            {
                thisDay = thisDay.AddDays(-1);
                allDates.Add(new dayObject { DayOfWeek = 0, day = 0, week = 0 });
            }

            for (DateTime date = firstOftargetMonth; date < firstOfNextMonth; date = date.AddDays(1))
            {
               
                allDates.Add(new dayObject { DayOfWeek = date.DayOfWeek, day = date.Day, week = week, TimeStamp = date.ToShortDateString() }
                
                );
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    week++;
                }

            }

            return allDates;
        }

        [HttpGet]
        [Route("get/calendar")]
        public HttpResponseMessage GetCalendar(HttpRequestMessage request)
        {

            var queryString = Request.GetQueryNameValuePairs();

            var year = int.Parse(queryString.First().Value);
            var month = int.Parse(queryString.Last().Value);
            var result = AllDatesInAMonth(year, month).GroupBy(a => a.week);
            var today = DateTime.Today.ToShortDateString();


            return Request.CreateResponse(HttpStatusCode.OK, new { result, today });
        }
    }
}

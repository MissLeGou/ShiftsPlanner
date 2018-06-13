using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models.ViewModels
{
    public class BookingDTO
    {
        public Guid BookingID { get; set; }
        public Guid ShiftID { get; set; }
        public string UserName { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}
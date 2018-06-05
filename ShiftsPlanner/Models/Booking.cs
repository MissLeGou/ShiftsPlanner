using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }
        public int? BookingDate { get; set; }
        public int? BookingTime { get; set; }
        public List<Shift> Shifts { get; set; }

    }
}
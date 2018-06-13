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
        public Guid BookingID { get; set; }
        public Guid ShiftID { get; set; }
        public string UserName  { get; set; }
        public Shift Shift { get; set; }
        
    }
}
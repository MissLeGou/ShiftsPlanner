using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models
{
    public class Event
    {
        [Key]
        public Guid EventID { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public List<Shift> Shifts { get; set; }
    }
}
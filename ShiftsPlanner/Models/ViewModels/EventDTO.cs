using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models.ViewModels
{
    public class EventDTO
    {
        public Guid EventID { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public List<Shift> Shifts { get; set; }
        
    }
}
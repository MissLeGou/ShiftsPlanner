using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models.ViewModels
{
    public class MyShiftDTO
    {
        public Guid ShiftID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
    }
}
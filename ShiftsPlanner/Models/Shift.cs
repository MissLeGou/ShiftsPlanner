using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models
{
    public class Shift
    {
        [Key]
        public int ShiftID { get; set; }
        public string Location { get; set; }
        public int? Date { get; set; }
        public int? StartTime { get; set; }
        public int? EndTime { get; set; }

    }
}
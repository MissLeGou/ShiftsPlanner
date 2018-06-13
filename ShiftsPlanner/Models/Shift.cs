using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models
{
    public class Shift
    {
        [Key]
        public Guid ShiftID { get; set; }
        public string ShiftTime { get; set; }
        public List<User> User { get; set; }
        public virtual Event Event { get; set; }
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        
    }
}
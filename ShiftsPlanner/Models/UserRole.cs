using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models
{
    public class UserRole
    {
        [Key]
        public int UserID { get; set; }
        public int RoleID { get; set; }
    }
}
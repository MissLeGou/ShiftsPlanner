using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShiftsPlanner.Models
{
    public class Role
    {
        [Key]
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
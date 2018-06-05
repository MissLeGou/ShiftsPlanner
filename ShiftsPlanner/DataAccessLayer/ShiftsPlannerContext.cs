using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ShiftsPlanner.Models.DataAccessLayer
{
    public class ShiftsPlannerContext : DbContext 
    {
        public ShiftsPlannerContext() : base("ShiftsPlannerContext") 
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Role> UserRoles { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
    }
}
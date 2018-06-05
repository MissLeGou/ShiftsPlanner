using ShiftsPlanner.Models.DataAccessLayer;
using System.Data.Entity.Migrations;

namespace ShiftsPlanner.DataAccessLayer
{
    public class Configuration : DbMigrationsConfiguration<ShiftsPlannerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
                    

    }
}
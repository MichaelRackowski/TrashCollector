namespace TrashCollectorfr.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrashCollectorfr.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TrashCollectorfr.Models.ApplicationDbContext";
        }

        protected override void Seed(TrashCollectorfr.Models.ApplicationDbContext context)
        {
            context.Days.AddOrUpdate(

                new Models.Day { DayOfWeek = "Monday" },
                new Models.Day { DayOfWeek = "Tuesday" },
                new Models.Day { DayOfWeek = "Wednesday" },
                new Models.Day { DayOfWeek = "Thursday" }, 
                new Models.Day { DayOfWeek = "Friday" },
                new Models.Day { DayOfWeek = "Saturday" },
                new Models.Day { DayOfWeek = "Sunday" }
                );





        }




          

        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data.
    
    }
}

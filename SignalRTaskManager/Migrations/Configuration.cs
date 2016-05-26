using SignalRTaskManager.Models;

namespace SignalRTaskManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SignalRTaskManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SignalRTaskManager.Models.ApplicationDbContext";
        }

        protected override void Seed(SignalRTaskManager.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Tasks.AddOrUpdate(
              p => p.Id,
              new TaskModel { Title = "Task 1", Description = "This is the first task"},
              new TaskModel { Title = "Task 2", Description = "This is the second task"},
              new TaskModel { Title = "Task 3", Description = "This is the third task"}
            );
            //
        }
    }
}

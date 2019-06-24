namespace FlowersWebApi.Migrations
{
    using FlowersWebApi.Models;
    using FlowersWebApi.Models.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FlowersDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FlowersDbContext context)
        {
            CheckOrAddNewManager(context, "Dima", "Vasilisivich");
            CheckOrAddNewManager(context, "Denis", "Sidorov");
        }

        private void CheckOrAddNewManager(FlowersDbContext context, string firstName, string lastName)
        {
            var manager = context.Managers.FirstOrDefault(m => m.FirstName == firstName && m.LastName == lastName);
            if (manager == null)
            {
                manager = new Manager
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Bdate = DateTime.Now
                };

                context.Managers.Add(manager);
                context.SaveChanges();
            }
        }
    }
}

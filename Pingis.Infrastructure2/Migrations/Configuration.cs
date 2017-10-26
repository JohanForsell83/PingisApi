using Pingis.Core.Models;

namespace Pingis.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pingis.DataModel.Database.PingisContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pingis.DataModel.Database.PingisContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Players.AddOrUpdate(
                new Player { FirstName = "Johan", LastName = "Forsell", DouchePoints = 0, Points = 100 },
                new Player { FirstName = "Xander", LastName = "Danielsson", DouchePoints = 100, Points = 0 },
                new Player { FirstName = "Jonas", LastName = "Lundell", DouchePoints = 500, Points = 0 }
            );
            
        }
    }
}

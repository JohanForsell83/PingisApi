using Pingis.Core;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pingis.Core.Models;
using System.Web.Configuration;
using Pingis.DataModel.Core;

namespace Pingis.DataModel.Database
{
    public class PingisContext : DbContext
    {
        public PingisContext(): base("PinginsContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Player>()
                .HasMany<Game>(p => p.Games)
                .WithMany(g => g.Players)
                .Map(pg =>
                {
                    pg.MapLeftKey("PlayerRefId");
                    pg.MapRightKey("GameRefId");
                    pg.ToTable("PlayerGame");
                });
        }
    }
}

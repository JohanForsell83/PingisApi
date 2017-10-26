using Pingis.Core;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Pingis.Core.Models;
using System.Web.Configuration;
using Pingis.DataModel.Core;
using Pingis.DataModel.Core.DbContext;

namespace Pingis.DataModel.Database
{
    public class PingisContext : DbContext, IPingisContext
    {
        public PingisContext(): base("PinginsContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

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

            modelBuilder.Entity<Tournament>()
                .HasMany<Player>(g => g.Players)
                .WithMany(t => t.Tournaments)
                .Map(tp =>
                {
                    tp.MapLeftKey("TournamentRefId");
                    tp.MapRightKey("PlayerRefId");
                    tp.ToTable("TournamentPlayer");
                });

            modelBuilder.Entity<Tournament>()
                .HasMany<Game>(g => g.Games)
                .WithMany(t => t.Tournaments)
                .Map(tp =>
                {
                    tp.MapLeftKey("TournamentRefId");
                    tp.MapRightKey("GameRefId");
                    tp.ToTable("TournamentGame");
                });
        }
    }
}

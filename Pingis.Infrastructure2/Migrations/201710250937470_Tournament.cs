namespace Pingis.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tournament : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfPlayers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TournamentGame",
                c => new
                    {
                        TournamentRefId = c.Int(nullable: false),
                        GameRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TournamentRefId, t.GameRefId })
                .ForeignKey("dbo.Tournament", t => t.TournamentRefId, cascadeDelete: true)
                .ForeignKey("dbo.Game", t => t.GameRefId, cascadeDelete: true)
                .Index(t => t.TournamentRefId)
                .Index(t => t.GameRefId);
            
            CreateTable(
                "dbo.TournamentPlayer",
                c => new
                    {
                        TournamentRefId = c.Int(nullable: false),
                        PlayerRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TournamentRefId, t.PlayerRefId })
                .ForeignKey("dbo.Tournament", t => t.TournamentRefId, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerRefId, cascadeDelete: true)
                .Index(t => t.TournamentRefId)
                .Index(t => t.PlayerRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentPlayer", "PlayerRefId", "dbo.Player");
            DropForeignKey("dbo.TournamentPlayer", "TournamentRefId", "dbo.Tournament");
            DropForeignKey("dbo.TournamentGame", "GameRefId", "dbo.Game");
            DropForeignKey("dbo.TournamentGame", "TournamentRefId", "dbo.Tournament");
            DropIndex("dbo.TournamentPlayer", new[] { "PlayerRefId" });
            DropIndex("dbo.TournamentPlayer", new[] { "TournamentRefId" });
            DropIndex("dbo.TournamentGame", new[] { "GameRefId" });
            DropIndex("dbo.TournamentGame", new[] { "TournamentRefId" });
            DropTable("dbo.TournamentPlayer");
            DropTable("dbo.TournamentGame");
            DropTable("dbo.Tournament");
        }
    }
}

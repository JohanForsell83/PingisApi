namespace Pingis.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Player1Score = c.Int(nullable: false),
                        Player2Score = c.Int(nullable: false),
                        WinnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DouchePoints = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerGame",
                c => new
                    {
                        PlayerRefId = c.Int(nullable: false),
                        GameRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerRefId, t.GameRefId })
                .ForeignKey("dbo.Player", t => t.PlayerRefId, cascadeDelete: true)
                .ForeignKey("dbo.Game", t => t.GameRefId, cascadeDelete: true)
                .Index(t => t.PlayerRefId)
                .Index(t => t.GameRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerGame", "GameRefId", "dbo.Game");
            DropForeignKey("dbo.PlayerGame", "PlayerRefId", "dbo.Player");
            DropIndex("dbo.PlayerGame", new[] { "GameRefId" });
            DropIndex("dbo.PlayerGame", new[] { "PlayerRefId" });
            DropTable("dbo.PlayerGame");
            DropTable("dbo.Player");
            DropTable("dbo.Game");
        }
    }
}

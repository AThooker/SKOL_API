namespace SKOL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PickingBackUp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kingdom",
                c => new
                    {
                        KingdomID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        King = c.String(nullable: false),
                        Colors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KingdomID);
            
            CreateTable(
                "dbo.Viking",
                c => new
                    {
                        VikingID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Job = c.Int(nullable: false),
                        KingdomID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VikingID)
                .ForeignKey("dbo.Kingdom", t => t.KingdomID, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.KingdomID)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        Gender = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Colors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viking", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Viking", "KingdomID", "dbo.Kingdom");
            DropIndex("dbo.Viking", new[] { "PlayerID" });
            DropIndex("dbo.Viking", new[] { "KingdomID" });
            DropTable("dbo.Player");
            DropTable("dbo.Viking");
            DropTable("dbo.Kingdom");
        }
    }
}

namespace SKOL.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutinKingdomColors : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Viking", "PlayerID", "dbo.Player");
            DropIndex("dbo.Viking", new[] { "PlayerID" });
            AlterColumn("dbo.Viking", "PlayerID", c => c.Int());
            CreateIndex("dbo.Viking", "PlayerID");
            AddForeignKey("dbo.Viking", "PlayerID", "dbo.Player", "PlayerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viking", "PlayerID", "dbo.Player");
            DropIndex("dbo.Viking", new[] { "PlayerID" });
            AlterColumn("dbo.Viking", "PlayerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Viking", "PlayerID");
            AddForeignKey("dbo.Viking", "PlayerID", "dbo.Player", "PlayerID", cascadeDelete: true);
        }
    }
}

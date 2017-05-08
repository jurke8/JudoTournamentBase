namespace JudoTournamentBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class competitor_update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitors", "CategoryId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Competitors", "CategoryId");
            AddForeignKey("dbo.Competitors", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Competitors", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Competitors", "Weight", c => c.Int(nullable: false));
            DropForeignKey("dbo.Competitors", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Competitors", new[] { "CategoryId" });
            DropColumn("dbo.Competitors", "CategoryId");
        }
    }
}

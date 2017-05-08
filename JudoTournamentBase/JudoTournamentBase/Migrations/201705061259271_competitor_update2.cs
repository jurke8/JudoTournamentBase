namespace JudoTournamentBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class competitor_update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Competitors", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Competitors", new[] { "Category_Id" });
            DropColumn("dbo.Competitors", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Competitors", "Category_Id", c => c.Guid());
            CreateIndex("dbo.Competitors", "Category_Id");
            AddForeignKey("dbo.Competitors", "Category_Id", "dbo.Categories", "Id");
        }
    }
}

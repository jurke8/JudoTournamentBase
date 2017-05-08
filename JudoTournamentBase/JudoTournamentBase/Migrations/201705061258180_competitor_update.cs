namespace JudoTournamentBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class competitor_update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Competitors", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Competitors", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Competitors", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Competitors", "Category_Id", c => c.Guid());
            CreateIndex("dbo.Competitors", "Category_Id");
            AddForeignKey("dbo.Competitors", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Competitors", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Competitors", new[] { "Category_Id" });
            AlterColumn("dbo.Competitors", "Category_Id", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Competitors", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Competitors", "CategoryId");
            AddForeignKey("dbo.Competitors", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}

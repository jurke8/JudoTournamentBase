namespace JudoTournamentBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clubs_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clubs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Gender = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Competitors", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.Competitors", "CategoryId", c => c.Guid(nullable: false));
            AddColumn("dbo.Competitors", "ClubId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Competitors", "CategoryId");
            CreateIndex("dbo.Competitors", "ClubId");
            AddForeignKey("dbo.Competitors", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Competitors", "ClubId", "dbo.Clubs", "Id", cascadeDelete: true);
            DropColumn("dbo.Competitors", "Category");
            DropColumn("dbo.Competitors", "Club");
            DropColumn("dbo.Competitors", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Competitors", "Country", c => c.String());
            AddColumn("dbo.Competitors", "Club", c => c.String());
            AddColumn("dbo.Competitors", "Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Competitors", "ClubId", "dbo.Clubs");
            DropForeignKey("dbo.Competitors", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Competitors", new[] { "ClubId" });
            DropIndex("dbo.Competitors", new[] { "CategoryId" });
            DropColumn("dbo.Competitors", "ClubId");
            DropColumn("dbo.Competitors", "CategoryId");
            DropColumn("dbo.Competitors", "Weight");
            DropTable("dbo.Clubs");
        }
    }
}

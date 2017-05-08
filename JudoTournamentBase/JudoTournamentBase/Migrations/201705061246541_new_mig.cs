namespace JudoTournamentBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clubs", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Clubs", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clubs", "Gender", c => c.String(nullable: false));
            DropColumn("dbo.Clubs", "Name");
        }
    }
}

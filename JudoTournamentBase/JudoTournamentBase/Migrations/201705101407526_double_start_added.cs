namespace JudoTournamentBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class double_start_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competitors", "DoubleStart", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Competitors", "DoubleStart");
        }
    }
}

namespace ShowRegSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "OrganizerID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "OrganizerID", c => c.Int(nullable: false));
        }
    }
}

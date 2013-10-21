namespace ShowRegSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Color", "NamePL", c => c.String());
            AddColumn("dbo.Color", "NameEN", c => c.String());
            DropColumn("dbo.Color", "NamePol");
            DropColumn("dbo.Color", "NameEng");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Color", "NameEng", c => c.String());
            AddColumn("dbo.Color", "NamePol", c => c.String());
            DropColumn("dbo.Color", "NameEN");
            DropColumn("dbo.Color", "NamePL");
        }
    }
}

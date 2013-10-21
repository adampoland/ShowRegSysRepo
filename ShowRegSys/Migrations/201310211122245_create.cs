namespace ShowRegSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breed",
                c => new
                    {
                        BreedID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Group = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BreedID);
            
            CreateTable(
                "dbo.Dog",
                c => new
                    {
                        DogId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        PKR = c.String(),
                        BreedID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        TattooOrChip = c.String(),
                        UserID = c.Int(nullable: false),
                        Breeder = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Titles = c.String(),
                    })
                .PrimaryKey(t => t.DogId)
                .ForeignKey("dbo.Breed", t => t.BreedID, cascadeDelete: true)
                .ForeignKey("dbo.Color", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.Gender", t => t.GenderID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.BreedID)
                .Index(t => t.ColorID)
                .Index(t => t.GenderID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        NamePol = c.String(),
                        NameEng = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        NamePL = c.String(),
                        NameEN = c.String(),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Adress = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        ShowID = c.Int(nullable: false),
                        DogID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Show", t => t.ShowID, cascadeDelete: true)
                .ForeignKey("dbo.Dog", t => t.DogID, cascadeDelete: true)
                .Index(t => t.ShowID)
                .Index(t => t.DogID);
            
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ShowID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        RankID = c.Int(nullable: false),
                        OrganizerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShowID)
                .ForeignKey("dbo.Rank", t => t.RankID, cascadeDelete: true)
                .ForeignKey("dbo.Organizer", t => t.OrganizerID, cascadeDelete: true)
                .Index(t => t.RankID)
                .Index(t => t.OrganizerID);
            
            CreateTable(
                "dbo.Rank",
                c => new
                    {
                        RankID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RankID);
            
            CreateTable(
                "dbo.Organizer",
                c => new
                    {
                        OrganizerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Telephone = c.String(),
                        BankAccount = c.String(),
                    })
                .PrimaryKey(t => t.OrganizerID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Show", new[] { "OrganizerID" });
            DropIndex("dbo.Show", new[] { "RankID" });
            DropIndex("dbo.Enrollment", new[] { "DogID" });
            DropIndex("dbo.Enrollment", new[] { "ShowID" });
            DropIndex("dbo.Dog", new[] { "UserID" });
            DropIndex("dbo.Dog", new[] { "GenderID" });
            DropIndex("dbo.Dog", new[] { "ColorID" });
            DropIndex("dbo.Dog", new[] { "BreedID" });
            DropForeignKey("dbo.Show", "OrganizerID", "dbo.Organizer");
            DropForeignKey("dbo.Show", "RankID", "dbo.Rank");
            DropForeignKey("dbo.Enrollment", "DogID", "dbo.Dog");
            DropForeignKey("dbo.Enrollment", "ShowID", "dbo.Show");
            DropForeignKey("dbo.Dog", "UserID", "dbo.User");
            DropForeignKey("dbo.Dog", "GenderID", "dbo.Gender");
            DropForeignKey("dbo.Dog", "ColorID", "dbo.Color");
            DropForeignKey("dbo.Dog", "BreedID", "dbo.Breed");
            DropTable("dbo.Organizer");
            DropTable("dbo.Rank");
            DropTable("dbo.Show");
            DropTable("dbo.Enrollment");
            DropTable("dbo.User");
            DropTable("dbo.Gender");
            DropTable("dbo.Color");
            DropTable("dbo.Dog");
            DropTable("dbo.Breed");
        }
    }
}

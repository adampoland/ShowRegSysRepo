namespace ShowRegSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breed",
                c => new
                    {
                        BreedID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PkrID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BreedID)
                .ForeignKey("dbo.Pkr", t => t.PkrID)
                .Index(t => t.PkrID);
            
            CreateTable(
                "dbo.Pkr",
                c => new
                    {
                        PkrID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PkrID);
            
            CreateTable(
                "dbo.Dog",
                c => new
                    {
                        DogId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        numerPKR = c.String(),
                        PkrID = c.Int(nullable: false),
                        BreedID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        TattooOrChip = c.String(),
                        UserProfileId = c.Int(nullable: false),
                        Breeder = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Titles = c.String(),
                    })
                .PrimaryKey(t => t.DogId)
                .ForeignKey("dbo.Pkr", t => t.PkrID)
                .ForeignKey("dbo.Breed", t => t.BreedID)
                .ForeignKey("dbo.Color", t => t.ColorID)
                .ForeignKey("dbo.Gender", t => t.GenderID)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileId)
                .Index(t => t.PkrID)
                .Index(t => t.BreedID)
                .Index(t => t.ColorID)
                .Index(t => t.GenderID)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        NamePL = c.String(),
                        NameEN = c.String(),
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
                "dbo.UserProfile",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                        Telephone = c.String(),
                        Email = c.String(),
                        OrganizerID = c.Int(),
                    })
                .PrimaryKey(t => t.UserProfileId)
                .ForeignKey("dbo.Organizer", t => t.OrganizerID)
                .Index(t => t.OrganizerID);
            
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
                        WebAdress = c.String(),
                    })
                .PrimaryKey(t => t.OrganizerID);
            
            CreateTable(
                "dbo.Show",
                c => new
                    {
                        ShowID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Place = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        RankID = c.Int(nullable: false),
                        Attention = c.String(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                        OrganizerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShowID)
                .ForeignKey("dbo.Rank", t => t.RankID)
                .ForeignKey("dbo.Organizer", t => t.OrganizerID)
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
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        ShowID = c.Int(nullable: false),
                        DogID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Show", t => t.ShowID)
                .ForeignKey("dbo.Dog", t => t.DogID)
                .ForeignKey("dbo.Class", t => t.ClassID)
                .Index(t => t.ShowID)
                .Index(t => t.DogID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        NamePL = c.String(),
                        NameEN = c.String(),
                    })
                .PrimaryKey(t => t.ClassID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Enrollment", new[] { "ClassID" });
            DropIndex("dbo.Enrollment", new[] { "DogID" });
            DropIndex("dbo.Enrollment", new[] { "ShowID" });
            DropIndex("dbo.Show", new[] { "OrganizerID" });
            DropIndex("dbo.Show", new[] { "RankID" });
            DropIndex("dbo.UserProfile", new[] { "OrganizerID" });
            DropIndex("dbo.Dog", new[] { "UserProfileId" });
            DropIndex("dbo.Dog", new[] { "GenderID" });
            DropIndex("dbo.Dog", new[] { "ColorID" });
            DropIndex("dbo.Dog", new[] { "BreedID" });
            DropIndex("dbo.Dog", new[] { "PkrID" });
            DropIndex("dbo.Breed", new[] { "PkrID" });
            DropForeignKey("dbo.Enrollment", "ClassID", "dbo.Class");
            DropForeignKey("dbo.Enrollment", "DogID", "dbo.Dog");
            DropForeignKey("dbo.Enrollment", "ShowID", "dbo.Show");
            DropForeignKey("dbo.Show", "OrganizerID", "dbo.Organizer");
            DropForeignKey("dbo.Show", "RankID", "dbo.Rank");
            DropForeignKey("dbo.UserProfile", "OrganizerID", "dbo.Organizer");
            DropForeignKey("dbo.Dog", "UserProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.Dog", "GenderID", "dbo.Gender");
            DropForeignKey("dbo.Dog", "ColorID", "dbo.Color");
            DropForeignKey("dbo.Dog", "BreedID", "dbo.Breed");
            DropForeignKey("dbo.Dog", "PkrID", "dbo.Pkr");
            DropForeignKey("dbo.Breed", "PkrID", "dbo.Pkr");
            DropTable("dbo.Class");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Rank");
            DropTable("dbo.Show");
            DropTable("dbo.Organizer");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Gender");
            DropTable("dbo.Color");
            DropTable("dbo.Dog");
            DropTable("dbo.Pkr");
            DropTable("dbo.Breed");
        }
    }
}

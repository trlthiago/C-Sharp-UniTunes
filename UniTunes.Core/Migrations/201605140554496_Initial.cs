namespace UniTunes.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAvailable = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Duration = c.Time(precision: 7),
                        UrlFeed = c.String(),
                        Quality = c.Int(),
                        Pages = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Category_Id = c.Int(),
                        Album_Id = c.Int(),
                        BookMarkList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .ForeignKey("dbo.BookMarkLists", t => t.BookMarkList_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Album_Id)
                .Index(t => t.BookMarkList_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Status = c.Int(nullable: false),
                        RecoveryPasswordHash = c.String(),
                        IsAdministrator = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Media_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Media", t => t.Media_Id)
                .Index(t => t.Media_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Buyer_Id = c.Int(),
                        Media_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Buyer_Id)
                .ForeignKey("dbo.Media", t => t.Media_Id)
                .Index(t => t.Buyer_Id)
                .Index(t => t.Media_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookMarkLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CurrentValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wallets", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.BookMarkLists", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Media", "BookMarkList_Id", "dbo.BookMarkLists");
            DropForeignKey("dbo.Media", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Media", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Users", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Purchases", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.Purchases", "Buyer_Id", "dbo.Users");
            DropIndex("dbo.Wallets", new[] { "Owner_Id" });
            DropIndex("dbo.BookMarkLists", new[] { "Owner_Id" });
            DropIndex("dbo.Purchases", new[] { "Media_Id" });
            DropIndex("dbo.Purchases", new[] { "Buyer_Id" });
            DropIndex("dbo.Users", new[] { "Media_Id" });
            DropIndex("dbo.Media", new[] { "BookMarkList_Id" });
            DropIndex("dbo.Media", new[] { "Album_Id" });
            DropIndex("dbo.Media", new[] { "Category_Id" });
            DropTable("dbo.Wallets");
            DropTable("dbo.BookMarkLists");
            DropTable("dbo.Categories");
            DropTable("dbo.Purchases");
            DropTable("dbo.Users");
            DropTable("dbo.Media");
            DropTable("dbo.Albums");
        }
    }
}

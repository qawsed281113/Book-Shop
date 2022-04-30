namespace yaMachina.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        pages = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        IsCountin = c.Boolean(nullable: false),
                        ID_Fio = c.Int(nullable: false),
                        ID_Genre = c.Int(nullable: false),
                        ID_Publisher = c.Int(nullable: false),
                        ID_Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FIOs", t => t.ID_Fio, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.ID_Genre, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.ID_Publisher, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.ID_Year, cascadeDelete: true)
                .Index(t => t.ID_Fio)
                .Index(t => t.ID_Genre)
                .Index(t => t.ID_Publisher)
                .Index(t => t.ID_Year);
            
            CreateTable(
                "dbo.FIOs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        YearPublished = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "ID_Year", "dbo.Years");
            DropForeignKey("dbo.Books", "ID_Publisher", "dbo.Publishers");
            DropForeignKey("dbo.Books", "ID_Genre", "dbo.Genres");
            DropForeignKey("dbo.Books", "ID_Fio", "dbo.FIOs");
            DropIndex("dbo.Books", new[] { "ID_Year" });
            DropIndex("dbo.Books", new[] { "ID_Publisher" });
            DropIndex("dbo.Books", new[] { "ID_Genre" });
            DropIndex("dbo.Books", new[] { "ID_Fio" });
            DropTable("dbo.Years");
            DropTable("dbo.Publishers");
            DropTable("dbo.Genres");
            DropTable("dbo.FIOs");
            DropTable("dbo.Books");
        }
    }
}

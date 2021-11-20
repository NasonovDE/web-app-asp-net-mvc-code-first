namespace KinoAfisha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilmCovers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFilm = c.String(nullable: false),
                        FilmYears = c.Int(nullable: false),
                        FilmCover_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FilmCovers", t => t.FilmCover_Id)
                .Index(t => t.FilmCover_Id);
            
            CreateTable(
                "dbo.Kinoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfBilets = c.Int(nullable: false),
                        Cinema = c.Int(nullable: false),
                        NextArrivalDate = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                        Film_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id)
                .Index(t => t.Film_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Films", "FilmCover_Id", "dbo.FilmCovers");
            DropIndex("dbo.Kinoes", new[] { "Film_Id" });
            DropIndex("dbo.Films", new[] { "FilmCover_Id" });
            DropTable("dbo.Kinoes");
            DropTable("dbo.Films");
            DropTable("dbo.FilmCovers");
        }
    }
}

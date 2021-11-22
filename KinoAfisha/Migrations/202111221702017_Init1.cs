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
                        Id = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFilm = c.String(nullable: false),
                        FilmYears = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kinoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumberOfBilets = c.Int(nullable: false),
                        Cinema = c.Int(nullable: false),
                        NextArrivalDate = c.DateTime(nullable: false),
                        KinoTime = c.DateTime(nullable: false),
                        CreateAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KinoFilms",
                c => new
                    {
                        Kino_Id = c.Int(nullable: false),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kino_Id, t.Film_Id })
                .ForeignKey("dbo.Kinoes", t => t.Kino_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Kino_Id)
                .Index(t => t.Film_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KinoFilms", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.KinoFilms", "Kino_Id", "dbo.Kinoes");
            DropForeignKey("dbo.FilmCovers", "Id", "dbo.Films");
            DropIndex("dbo.KinoFilms", new[] { "Film_Id" });
            DropIndex("dbo.KinoFilms", new[] { "Kino_Id" });
            DropIndex("dbo.FilmCovers", new[] { "Id" });
            DropTable("dbo.KinoFilms");
            DropTable("dbo.Kinoes");
            DropTable("dbo.Films");
            DropTable("dbo.FilmCovers");
        }
    }
}

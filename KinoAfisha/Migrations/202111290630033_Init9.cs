namespace KinoAfisha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cinemas", "Kino_Id", "dbo.Kinoes");
            DropForeignKey("dbo.Cinemas", "Kino_Id1", "dbo.Kinoes");
            DropForeignKey("dbo.Kinoes", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.FilmCinemas", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.FilmCinemas", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films");
            DropIndex("dbo.Cinemas", new[] { "Kino_Id" });
            DropIndex("dbo.Cinemas", new[] { "Kino_Id1" });
            DropIndex("dbo.Kinoes", new[] { "Cinema_Id" });
            DropIndex("dbo.Kinoes", new[] { "Film_Id" });
            DropIndex("dbo.FilmCinemas", new[] { "Film_Id" });
            DropIndex("dbo.FilmCinemas", new[] { "Cinema_Id" });
            CreateTable(
                "dbo.KinoCinemas",
                c => new
                    {
                        Kino_Id = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kino_Id, t.Cinema_Id })
                .ForeignKey("dbo.Kinoes", t => t.Kino_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id, cascadeDelete: true)
                .Index(t => t.Kino_Id)
                .Index(t => t.Cinema_Id);
            
            CreateTable(
                "dbo.FilmKinoes",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Kino_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Kino_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Kinoes", t => t.Kino_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Kino_Id);
            
            DropColumn("dbo.Cinemas", "Kino_Id");
            DropColumn("dbo.Cinemas", "Kino_Id1");
            DropColumn("dbo.Kinoes", "Cinema_Id");
            DropColumn("dbo.Kinoes", "Film_Id");
            DropTable("dbo.FilmCinemas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilmCinemas",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Cinema_Id });
            
            AddColumn("dbo.Kinoes", "Film_Id", c => c.Int());
            AddColumn("dbo.Kinoes", "Cinema_Id", c => c.Int());
            AddColumn("dbo.Cinemas", "Kino_Id1", c => c.Int());
            AddColumn("dbo.Cinemas", "Kino_Id", c => c.Int());
            DropForeignKey("dbo.FilmKinoes", "Kino_Id", "dbo.Kinoes");
            DropForeignKey("dbo.FilmKinoes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.KinoCinemas", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.KinoCinemas", "Kino_Id", "dbo.Kinoes");
            DropIndex("dbo.FilmKinoes", new[] { "Kino_Id" });
            DropIndex("dbo.FilmKinoes", new[] { "Film_Id" });
            DropIndex("dbo.KinoCinemas", new[] { "Cinema_Id" });
            DropIndex("dbo.KinoCinemas", new[] { "Kino_Id" });
            DropTable("dbo.FilmKinoes");
            DropTable("dbo.KinoCinemas");
            CreateIndex("dbo.FilmCinemas", "Cinema_Id");
            CreateIndex("dbo.FilmCinemas", "Film_Id");
            CreateIndex("dbo.Kinoes", "Film_Id");
            CreateIndex("dbo.Kinoes", "Cinema_Id");
            CreateIndex("dbo.Cinemas", "Kino_Id1");
            CreateIndex("dbo.Cinemas", "Kino_Id");
            AddForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films", "Id");
            AddForeignKey("dbo.FilmCinemas", "Cinema_Id", "dbo.Cinemas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilmCinemas", "Film_Id", "dbo.Films", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Kinoes", "Cinema_Id", "dbo.Cinemas", "Id");
            AddForeignKey("dbo.Cinemas", "Kino_Id1", "dbo.Kinoes", "Id");
            AddForeignKey("dbo.Cinemas", "Kino_Id", "dbo.Kinoes", "Id");
        }
    }
}

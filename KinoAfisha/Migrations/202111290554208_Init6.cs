namespace KinoAfisha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Kinoes", "Film_Id1", "dbo.Films");
            DropForeignKey("dbo.Films", "Kino_Id", "dbo.Kinoes");
            DropForeignKey("dbo.Films", "Cinema_Id", "dbo.Cinemas");
            DropIndex("dbo.Kinoes", new[] { "Film_Id" });
            DropIndex("dbo.Kinoes", new[] { "Film_Id1" });
            DropIndex("dbo.Films", new[] { "Kino_Id" });
            DropIndex("dbo.Films", new[] { "Cinema_Id" });
            CreateTable(
                "dbo.FilmCinemas",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Cinema_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cinemas", t => t.Cinema_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
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
            
            DropColumn("dbo.Kinoes", "Film_Id");
            DropColumn("dbo.Kinoes", "Film_Id1");
            DropColumn("dbo.Films", "Kino_Id");
            DropColumn("dbo.Films", "Cinema_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "Cinema_Id", c => c.Int());
            AddColumn("dbo.Films", "Kino_Id", c => c.Int());
            AddColumn("dbo.Kinoes", "Film_Id1", c => c.Int());
            AddColumn("dbo.Kinoes", "Film_Id", c => c.Int());
            DropForeignKey("dbo.FilmKinoes", "Kino_Id", "dbo.Kinoes");
            DropForeignKey("dbo.FilmKinoes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.FilmCinemas", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.FilmCinemas", "Film_Id", "dbo.Films");
            DropIndex("dbo.FilmKinoes", new[] { "Kino_Id" });
            DropIndex("dbo.FilmKinoes", new[] { "Film_Id" });
            DropIndex("dbo.FilmCinemas", new[] { "Cinema_Id" });
            DropIndex("dbo.FilmCinemas", new[] { "Film_Id" });
            DropTable("dbo.FilmKinoes");
            DropTable("dbo.FilmCinemas");
            CreateIndex("dbo.Films", "Cinema_Id");
            CreateIndex("dbo.Films", "Kino_Id");
            CreateIndex("dbo.Kinoes", "Film_Id1");
            CreateIndex("dbo.Kinoes", "Film_Id");
            AddForeignKey("dbo.Films", "Cinema_Id", "dbo.Cinemas", "Id");
            AddForeignKey("dbo.Films", "Kino_Id", "dbo.Kinoes", "Id");
            AddForeignKey("dbo.Kinoes", "Film_Id1", "dbo.Films", "Id");
            AddForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films", "Id");
        }
    }
}

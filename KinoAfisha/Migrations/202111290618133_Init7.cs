namespace KinoAfisha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.KinoCinemas", "Kino_Id", "dbo.Kinoes");
            DropForeignKey("dbo.KinoCinemas", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.FilmKinoes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.FilmKinoes", "Kino_Id", "dbo.Kinoes");
            DropIndex("dbo.KinoCinemas", new[] { "Kino_Id" });
            DropIndex("dbo.KinoCinemas", new[] { "Cinema_Id" });
            DropIndex("dbo.FilmKinoes", new[] { "Film_Id" });
            DropIndex("dbo.FilmKinoes", new[] { "Kino_Id" });
            AddColumn("dbo.Cinemas", "Kino_Id", c => c.Int());
            AddColumn("dbo.Cinemas", "Kino_Id1", c => c.Int());
            AddColumn("dbo.Kinoes", "Cinema_Id", c => c.Int());
            AddColumn("dbo.Kinoes", "Film_Id", c => c.Int());
            CreateIndex("dbo.Cinemas", "Kino_Id");
            CreateIndex("dbo.Cinemas", "Kino_Id1");
            CreateIndex("dbo.Kinoes", "Cinema_Id");
            CreateIndex("dbo.Kinoes", "Film_Id");
            AddForeignKey("dbo.Cinemas", "Kino_Id", "dbo.Kinoes", "Id");
            AddForeignKey("dbo.Cinemas", "Kino_Id1", "dbo.Kinoes", "Id");
            AddForeignKey("dbo.Kinoes", "Cinema_Id", "dbo.Cinemas", "Id");
            AddForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films", "Id");
            DropTable("dbo.KinoCinemas");
            DropTable("dbo.FilmKinoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilmKinoes",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Kino_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Kino_Id });
            
            CreateTable(
                "dbo.KinoCinemas",
                c => new
                    {
                        Kino_Id = c.Int(nullable: false),
                        Cinema_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kino_Id, t.Cinema_Id });
            
            DropForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Kinoes", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.Cinemas", "Kino_Id1", "dbo.Kinoes");
            DropForeignKey("dbo.Cinemas", "Kino_Id", "dbo.Kinoes");
            DropIndex("dbo.Kinoes", new[] { "Film_Id" });
            DropIndex("dbo.Kinoes", new[] { "Cinema_Id" });
            DropIndex("dbo.Cinemas", new[] { "Kino_Id1" });
            DropIndex("dbo.Cinemas", new[] { "Kino_Id" });
            DropColumn("dbo.Kinoes", "Film_Id");
            DropColumn("dbo.Kinoes", "Cinema_Id");
            DropColumn("dbo.Cinemas", "Kino_Id1");
            DropColumn("dbo.Cinemas", "Kino_Id");
            CreateIndex("dbo.FilmKinoes", "Kino_Id");
            CreateIndex("dbo.FilmKinoes", "Film_Id");
            CreateIndex("dbo.KinoCinemas", "Cinema_Id");
            CreateIndex("dbo.KinoCinemas", "Kino_Id");
            AddForeignKey("dbo.FilmKinoes", "Kino_Id", "dbo.Kinoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilmKinoes", "Film_Id", "dbo.Films", "Id", cascadeDelete: true);
            AddForeignKey("dbo.KinoCinemas", "Cinema_Id", "dbo.Cinemas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.KinoCinemas", "Kino_Id", "dbo.Kinoes", "Id", cascadeDelete: true);
        }
    }
}

namespace KinoAfisha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilmKinoes", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.FilmKinoes", "Kino_Id", "dbo.Kinoes");
            DropIndex("dbo.FilmKinoes", new[] { "Film_Id" });
            DropIndex("dbo.FilmKinoes", new[] { "Kino_Id" });
            AddColumn("dbo.Kinoes", "Film_Id", c => c.Int());
            AddColumn("dbo.Kinoes", "Film_Id1", c => c.Int());
            AddColumn("dbo.Films", "Kino_Id", c => c.Int());
            AddColumn("dbo.Films", "Cinema_Id", c => c.Int());
            CreateIndex("dbo.Kinoes", "Film_Id");
            CreateIndex("dbo.Kinoes", "Film_Id1");
            CreateIndex("dbo.Films", "Kino_Id");
            CreateIndex("dbo.Films", "Cinema_Id");
            AddForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films", "Id");
            AddForeignKey("dbo.Kinoes", "Film_Id1", "dbo.Films", "Id");
            AddForeignKey("dbo.Films", "Kino_Id", "dbo.Kinoes", "Id");
            AddForeignKey("dbo.Films", "Cinema_Id", "dbo.Cinemas", "Id");
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
            
            DropForeignKey("dbo.Films", "Cinema_Id", "dbo.Cinemas");
            DropForeignKey("dbo.Films", "Kino_Id", "dbo.Kinoes");
            DropForeignKey("dbo.Kinoes", "Film_Id1", "dbo.Films");
            DropForeignKey("dbo.Kinoes", "Film_Id", "dbo.Films");
            DropIndex("dbo.Films", new[] { "Cinema_Id" });
            DropIndex("dbo.Films", new[] { "Kino_Id" });
            DropIndex("dbo.Kinoes", new[] { "Film_Id1" });
            DropIndex("dbo.Kinoes", new[] { "Film_Id" });
            DropColumn("dbo.Films", "Cinema_Id");
            DropColumn("dbo.Films", "Kino_Id");
            DropColumn("dbo.Kinoes", "Film_Id1");
            DropColumn("dbo.Kinoes", "Film_Id");
            CreateIndex("dbo.FilmKinoes", "Kino_Id");
            CreateIndex("dbo.FilmKinoes", "Film_Id");
            AddForeignKey("dbo.FilmKinoes", "Kino_Id", "dbo.Kinoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FilmKinoes", "Film_Id", "dbo.Films", "Id", cascadeDelete: true);
        }
    }
}

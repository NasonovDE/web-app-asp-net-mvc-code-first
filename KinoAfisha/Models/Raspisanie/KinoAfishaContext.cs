using System.Data.Entity;

namespace KinoAfisha.Models
{
    public class KinoAfishaContext : DbContext
    {

        public DbSet<Film> Films { get; set; }
        public DbSet<Kino> Kinos { get; set; }
        public DbSet<FilmCover> FilmCover { get; set; }
        public KinoAfishaContext() : base("KinoAfishaEntity")
        { }
    }
}
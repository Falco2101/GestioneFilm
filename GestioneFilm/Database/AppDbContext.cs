using GestioneFilm.Models;
using Microsoft.EntityFrameworkCore;

namespace GestioneFilm.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Film> Film { get; set; }
    }
}

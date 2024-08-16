using GuitarMan.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarMan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song { Id = 1, Artist = "4 Non Blondes", Title = "What's Up?", Link = "https://www.youtube.com/watch?v=-7wsYYY1o98" },
                new Song { Id = 2, Artist = "Johnny Cash", Title = "Hurt", Link = "https://www.youtube.com/watch?v=CrQguKCnYTI" },
                new Song { Id = 3, Artist = "Neil Young", Title = "Heart of Gold", Link = "https://www.youtube.com/watch?v=U0MKyH48OhU" }
            );
        }

    }
}

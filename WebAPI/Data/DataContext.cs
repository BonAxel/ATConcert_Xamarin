using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Models.Junctions;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConcertGenres>()
                .HasKey(pc => new { pc.ConcertId, pc.GenreId });

            modelBuilder.Entity<ConcertGenres>()
                .HasOne(a => a.Concert)
                .WithMany(pc => pc.ConcertGenres)
                .HasForeignKey(pc => pc.ConcertId);

            modelBuilder.Entity<ConcertGenres>()
                .HasOne(a => a.Genre)
                .WithMany(pc => pc.ConcertGenres)
                .HasForeignKey(pc => pc.GenreId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using NotesWithTravelling.Models;

namespace NotesWithTravelling.Data
{
    public class TravelDbContext : DbContext
    {
        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) 
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Destination)
                .WithMany(d => d.Notes)
                .HasForeignKey(d => d.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}

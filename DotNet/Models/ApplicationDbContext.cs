using Microsoft.EntityFrameworkCore;

namespace RandomDataGenerator.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Personal> Personals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("YourConnectionStringFromAppSettings");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasIndex(g => g.Name).IsUnique();
            modelBuilder.Entity<Hobby>().HasIndex(h => h.Name).IsUnique();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MotorbikeShop.Entities;

namespace MotorbikeShop.Database
{
    public class MotorbikeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Motorbike> Motorbikes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ConnectionString
            optionsBuilder.UseSqlServer("Server=localhost;Database=motorBikeDB;User Id=SA;Password=MyPassword123#;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OnRun Seed Admin
            modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                Username = "nikiv",
                Password = "nikipass",
                Email = "admin@admin.com",
                Role = "Admin"
            });
        }
    }
}

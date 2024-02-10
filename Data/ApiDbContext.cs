using Microsoft.EntityFrameworkCore;
using TinyUrlClone.Models;

namespace TinyUrlClone.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Models.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            modelBuilder.Entity<User>().Property(user => user.Id).HasColumnName("id").IsRequired();
            modelBuilder.Entity<User>().Property(user => user.FullName).HasColumnName("fullname").IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Password).HasColumnName("password").IsRequired();
            modelBuilder.Entity<User>().Property(user => user.CreatedAt).HasColumnName("created_at").IsRequired();
            modelBuilder.Entity<User>().Property(user => user.UserName).HasColumnName("username").IsRequired();
            
        }
    }
}

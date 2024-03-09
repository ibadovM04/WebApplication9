using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Data
{
    public class ApplicationDbcontext:DbContext
    {
        public DbSet<Slider> Sliders { get; set; }

        public ApplicationDbcontext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slider>(entity =>
            {
               
                entity.Property(p => p.Slogan).IsRequired().HasMaxLength(500);              
                entity.Property(p => p.ImageUrl).IsRequired().HasMaxLength(1000);
            });
        }


    }
}

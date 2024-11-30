using BestGuide.Modules.Domain.Enums;
using BestGuide.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BestGuide.Modules.Infrastructure
{
    public class ModulesDbContext : DbContext
    {
        public ModulesDbContext(DbContextOptions<ModulesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelContact>(entity =>
            {
                entity.Property(e => e.Type)
                      .HasConversion(
                          v => v.ToString(),
                          v => (HotelContactType)Enum.Parse(typeof(HotelContactType), v)
                      )
                      .HasMaxLength(50);
            });
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelContact> Contacts { get; set; }
    }
}

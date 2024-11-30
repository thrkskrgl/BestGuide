using BestGuide.Report.Domain.Enums;
using BestGuide.Report.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BestGuide.Report.Infrastructure
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelReport>(entity =>
            {
                entity.Property(e => e.Status)
                      .HasConversion(
                          v => v.ToString(),
                          v => (ReportStatus)Enum.Parse(typeof(ReportStatus), v)
                      )
                      .HasMaxLength(50);
            });
        }

        public virtual DbSet<HotelReport> HotelReports { get; set; }
    }
}

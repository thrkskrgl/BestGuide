using BestGuide.Modules.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BestGuide.Modules.Infrastructure
{
    public class ModulesDbContext : DbContext
    {
        public ModulesDbContext(DbContextOptions<ModulesDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelContact> Contacts { get; set; }
    }
}

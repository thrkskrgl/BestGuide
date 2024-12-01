using BestGuide.Common.EFCore;
using BestGuide.Modules.Domain.Models;
using BestGuide.Modules.Domain.Persistence;

namespace BestGuide.Modules.Infrastructure.Persistence
{
    public class HotelContactRepository : RepositoryBase<HotelContact>, IHotelContactRepository
    {
        public HotelContactRepository(ModulesDbContext context) : base(context)
        {
        }
    }
}

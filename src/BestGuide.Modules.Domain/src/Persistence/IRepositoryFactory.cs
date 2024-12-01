namespace BestGuide.Modules.Domain.Persistence
{
    public partial interface IRepositoryFactory : IDisposable
    {
        IHotelRepository GetHotelRepository();
        IHotelContactRepository GetHotelContactRepository();
    }
}

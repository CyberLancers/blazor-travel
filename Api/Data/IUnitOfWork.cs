using BlazorAssemblyTravel.Api.Data.Repositories;

namespace BlazorAssemblyTravel.Api.Data
{
    public interface IUnitOfWork
    {
        CruiseLineRepository CruiseLineRepository { get; }
        DestinationRepository DestinationRepository { get; }
        ItineraryDestinationRepository ItineraryDestinationRepository { get; }
        ItineraryRepository ItineraryRepository { get; }
        ItineraryStatisticRepository ItineraryStatisticRepository { get; }
        PriceResultRepository PriceResultRepository { get; }
        RateRepository RateRepository { get; }
        RegionRepository RegionRepository { get; }
        RoomTypeRepository RoomTypeRepository { get; }
        ShipRepository ShipRepository { get; }

        Task Save();
        void Dispose();
    }
}

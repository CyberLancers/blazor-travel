using BlazorAssemblyTravel.Api.Data.Repositories;

namespace BlazorAssemblyTravel.Api.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CruisePriceWatchContext _context;

        private bool _disposed;
        public CruiseLineRepository CruiseLineRepository { get; }
        public DestinationRepository DestinationRepository { get; }
        public ItineraryDestinationRepository ItineraryDestinationRepository { get; }
        public ItineraryRepository ItineraryRepository { get; }
        public ItineraryStatisticRepository ItineraryStatisticRepository { get; }
        public PriceResultRepository PriceResultRepository { get; }
        public RateRepository RateRepository { get; }
        public RegionRepository RegionRepository { get; }
        public RoomTypeRepository RoomTypeRepository { get; }
        public ShipRepository ShipRepository { get; }

        public UnitOfWork(CruisePriceWatchContext context)
        {
            _context = context;
            CruiseLineRepository= new CruiseLineRepository(_context);
            DestinationRepository= new DestinationRepository(_context);
            ItineraryDestinationRepository= new ItineraryDestinationRepository(_context);
            ItineraryRepository= new ItineraryRepository(_context);
            ItineraryStatisticRepository= new ItineraryStatisticRepository(_context);
            PriceResultRepository= new PriceResultRepository(_context);
            RateRepository= new RateRepository(_context);
            RegionRepository= new RegionRepository(_context);
            RoomTypeRepository= new RoomTypeRepository(_context);
            ShipRepository= new ShipRepository(_context);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

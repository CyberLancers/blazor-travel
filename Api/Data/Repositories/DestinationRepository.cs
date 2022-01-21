using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class DestinationRepository : BaseRepository<Destination>
    {
        public DestinationRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
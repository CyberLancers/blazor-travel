using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class ItineraryDestinationRepository : BaseRepository<ItineraryDestination>
    {
        public ItineraryDestinationRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class ItineraryRepository : BaseRepository<Itinerary>
    {
        public ItineraryRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
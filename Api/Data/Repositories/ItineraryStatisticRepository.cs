using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class ItineraryStatisticRepository : BaseRepository<ItineraryStatistic>
    {
        public ItineraryStatisticRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
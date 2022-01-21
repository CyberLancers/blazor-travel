using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class RegionRepository : BaseRepository<Region>
    {
        public RegionRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
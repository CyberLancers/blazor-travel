using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class CruiseLineRepository : BaseRepository<CruiseLine>
    {
        public CruiseLineRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
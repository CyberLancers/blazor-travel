using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class RateRepository : BaseRepository<Rate>
    {
        public RateRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
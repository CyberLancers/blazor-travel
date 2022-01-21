using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class PriceResultRepository : BaseRepository<PriceResult>
    {
        public PriceResultRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
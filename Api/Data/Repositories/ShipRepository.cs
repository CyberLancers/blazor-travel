using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class ShipRepository : BaseRepository<Ship>
    {
        public ShipRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
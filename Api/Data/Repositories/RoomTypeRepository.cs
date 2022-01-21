using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data.Repositories
{
    public class RoomTypeRepository : BaseRepository<RoomType>
    {
        public RoomTypeRepository(CruisePriceWatchContext context) : base(context)
        {
        }
    }
}
using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class TopDestinations
{
    protected List<Destination> Destinations { get; set; }
    
    [Inject]
    protected ICruiseService cruiseService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Destinations = await cruiseService.GetDestinations();
            Destinations = Destinations.Where(c => c.ParentRegionId == c.RegionId).OrderBy(c => c.SortOrder).Skip(1).Take(13).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
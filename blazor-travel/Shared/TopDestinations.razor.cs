using BlazorAssemblyTravel.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class TopDestinations
{
    [Inject] 
    public HttpClient Http { get; set; }
    
    protected List<Destination> Destinations { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            Destinations = await Http.GetFromJsonAsync<List<Destination>>("/api/Destinations") ?? new List<Destination>();
            Destinations = Destinations.Where(c => c.ParentRegionId == c.RegionId).OrderBy(c => c.SortOrder).Skip(1).Take(13).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
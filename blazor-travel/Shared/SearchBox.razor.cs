using BlazorAssemblyTravel.Shared;
using BlazorAssemblyTravel.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class SearchBox
{
    [Inject] 
    public HttpClient Http { get; set; }
    protected List<Destination> Destinations { get; set; }
    protected List<CruiseLine> CruiseLines { get; set; }
    protected List<string> DepartureDates { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            Destinations = await Http.GetFromJsonAsync<List<Destination>>("/api/Destinations") ?? new List<Destination>();
            CruiseLines = await Http.GetFromJsonAsync<List<CruiseLine>>("/api/CruiseLines") ?? new List<CruiseLine>();
            DepartureDates = new List<string>();
            DateUtils.CreateDateList(DateTime.Now.AddYears(-10), 18).ForEach(d => DepartureDates.Add(d.ToString("MMMM yyyy")));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
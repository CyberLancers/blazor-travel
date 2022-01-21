using BlazorAssemblyTravel.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class TopCruiseLines
{
    [Inject] 
    public HttpClient Http { get; set; }
    
    protected List<CruiseLine> CruiseLines { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            CruiseLines = await Http.GetFromJsonAsync<List<CruiseLine>>("/api/CruiseLines") ?? new List<CruiseLine>();
            CruiseLines = CruiseLines.Where(c => c.IsFeatured).OrderBy(c => c.SortOrder).Take(11).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
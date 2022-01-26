using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class TopCruiseLines
{
    protected List<CruiseLine> CruiseLines { get; set; }
    
    [Inject]
    protected ICruiseService cruiseService { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            CruiseLines = await cruiseService.GetCruiseLines();
            CruiseLines = CruiseLines.Where(c => c.IsFeatured).OrderBy(c => c.SortOrder).Take(11).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class CruiseDeals
{
    protected List<CruiseDeal> Deals { get; set; }
    [Inject]
    protected ICruiseService cruiseService { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            Deals = await cruiseService.GetCruiseDeals();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
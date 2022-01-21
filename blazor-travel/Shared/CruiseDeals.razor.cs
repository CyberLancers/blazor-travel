using BlazorAssemblyTravel.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class CruiseDeals
{
    [Inject] 
    public HttpClient Http { get; set; }
    
    protected List<CruiseDeal> Deals { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            Deals = await Http.GetFromJsonAsync<List<CruiseDeal>>("/api/CruiseDeals") ?? new List<CruiseDeal>();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
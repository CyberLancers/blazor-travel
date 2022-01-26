using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace blazor_travel.Pages;

public partial class DestinationResults
{
    public string Title { get; set; }
    public string DateRange { get; set; }

    [Parameter]
    public string DestinationName { get; set; }
    
    private ItinerarySearchCriteria criteria;
    
    [Inject]
    private ICruiseService cruiseService { get; set; }

    public DestinationResults()
    {
        criteria = new ItinerarySearchCriteria();
    }
    
    protected override async Task OnInitializedAsync()
    {
        await FillSearchCriteriaFromRequest();
        BuildTitle();
    }

    private async Task FillSearchCriteriaFromRequest()
    {
        criteria.Region = await cruiseService.GetDestinationByName(DestinationName);

        criteria.NumberDays = "Any";
        
        criteria.DepartureDate = DateTime.Today.AddMonths(1);
    }
    
    private void BuildTitle()
    {
        Title = criteria.Region.Name + " Cruises";

        DateRange = criteria.DepartureDate.ToString("MMMM yyyy");
    }
}
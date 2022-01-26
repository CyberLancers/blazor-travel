using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace blazor_travel.Pages;

public partial class Results
{
    public string Title { get; set; }
    public string DateRange { get; set; }

    private ItinerarySearchCriteria criteria;
    
    [Inject]
    private NavigationManager NavManager { get; set; }
    
    [Inject]
    private ICruiseService cruiseService { get; set; }

    public Results()
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
        var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
        QueryHelpers.ParseQuery(uri.Query).TryGetValue("d", out var destinationId);
        QueryHelpers.ParseQuery(uri.Query).TryGetValue("c", out var cruiseLineId);
        QueryHelpers.ParseQuery(uri.Query).TryGetValue("dt", out var departure);
        QueryHelpers.ParseQuery(uri.Query).TryGetValue("l", out var length);
        
        criteria.CruiseLine = await cruiseService.GetCruiseLine(cruiseLineId);
        criteria.Region = await cruiseService.GetDestination(destinationId);
        
        if (criteria.CruiseLine?.CruiseLineId == 18)
            criteria.CruiseLine = null;

        if (criteria.Region?.RegionId == 30)
            criteria.Region = null;

        criteria.NumberDays = "Any";
        
        DateTime.TryParse(departure, out var startDate);
        criteria.DepartureDate = startDate < DateTime.Today ? DateTime.Today.AddMonths(1) : startDate;
    }
    
    private void BuildTitle()
    {
        if (criteria.Region != null)
        {
            Title = criteria.Region.Name + " Cruise";
        }

        DateRange = criteria.DepartureDate.ToString("MMMM yyyy");
    }
}
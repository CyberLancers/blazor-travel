using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace blazor_travel.Pages;

public partial class Details
{
    public string Title { get; set; }
    public string Title2 { get; set; }
    public string DateRange { get; set; }

    private ItinerarySearchCriteria criteria;
    
    [Parameter]
    public int itineraryId { get; set; }
    
    [Inject]
    private ICruiseService cruiseService { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        await FillSearchCriteriaFromRequest();
        await BuildTitle();
    }

    private async Task FillSearchCriteriaFromRequest()
    {
        criteria = new ItinerarySearchCriteria();
        criteria.ItineraryId = itineraryId;
    }
    
    private async Task BuildTitle()
    {
        if (criteria.ItineraryId == null)
            return;
        
        var itinerary = await cruiseService.GetItinerary(criteria.ItineraryId.Value);
        Title2 = itinerary.Title;
        DateRange = itinerary.DateStart.ToString("d") + " - " + itinerary.DateEnd.ToString("d");
        Title = itinerary.CruiseLineName + ": " + itinerary.ShipName;
        
        //CreateChart(info);
    }
}
using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace blazor_travel.Pages;

public partial class CruiseLineResults
{
    public string Title { get; set; }
    public string DateRange { get; set; }

    [Parameter]
    public string CruiseLineName { get; set; }
    
    private ItinerarySearchCriteria criteria;
    
    [Inject]
    private ICruiseService cruiseService { get; set; }

    public CruiseLineResults()
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
        criteria.CruiseLine = await cruiseService.GetCruiseLineByName(CruiseLineName);

        if (criteria.CruiseLine?.CruiseLineId == 18)
            criteria.CruiseLine = null;

        criteria.NumberDays = "Any";
        
        criteria.DepartureDate = DateTime.Today.AddMonths(1);
    }
    
    private void BuildTitle()
    {
        Title = criteria.CruiseLine.Name + " Cruises";

        DateRange = criteria.DepartureDate.ToString("MMMM yyyy");
    }
}
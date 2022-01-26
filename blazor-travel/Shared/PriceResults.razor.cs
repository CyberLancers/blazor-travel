using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class PriceResults
{
    [Parameter]
    public Itinerary? Itinerary { get; set; }
    
    [Parameter]
    public bool IsGraph { get; set; }
    
    [Inject]
    protected ICruiseService CruiseService { get; set; }

    protected decimal? InsideRate { get; set; }
    protected decimal? OutsideRate { get; set; }
    protected decimal? BalconyRate { get; set; }
    protected decimal? SuiteRate { get; set; }
    protected decimal? InsideRatePerson { get; set; }
    protected decimal? OutsideRatePerson { get; set; }
    protected decimal? BalconyRatePerson { get; set; }
    protected decimal? SuiteRatePerson { get; set; }
    
    protected override async Task OnParametersSetAsync()
    {
        await BindPrices();
    }

    private async Task BindPrices()
    {
        if (Itinerary == null || Itinerary.Nights == 0)
            return;

        InsideRate = await CruiseService.GetRate(Itinerary.ItineraryId, 1);
        OutsideRate = await CruiseService.GetRate(Itinerary.ItineraryId, 2);
        BalconyRate = await CruiseService.GetRate(Itinerary.ItineraryId, 3);
        SuiteRate = await CruiseService.GetRate(Itinerary.ItineraryId, 4);

        InsideRatePerson = InsideRate / Itinerary.Nights;
        OutsideRatePerson = OutsideRate / Itinerary.Nights;
        BalconyRatePerson = BalconyRate / Itinerary.Nights;
        SuiteRatePerson = SuiteRate / Itinerary.Nights;
    }
}
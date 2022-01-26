using BlazorAssemblyTravel.Shared.Models;
using Business.Data.DataObjects;
using Business.Services;
using Microsoft.AspNetCore.Components;
using Itinerary = BlazorAssemblyTravel.Shared.Models.Itinerary;

namespace blazor_travel.Shared;

public partial class SearchResultsList
{
    [Parameter]
    public ItinerarySearchCriteria? SearchCriteria { get; set; }
    
    [Parameter]
    public bool IsGraph { get; set; }
    
    [Inject]
    protected ICruiseService cruiseService { get; set; }
    protected string? Message { get; set; }
    protected int TotalPerPage { get; set; }
    protected int CurrentPage { get; set; }
    protected int TotalResults { get; set; }
    
    protected int TotalPages { get; set; }
    protected List<Itinerary> Itineraries { get; set; }

    public SearchResultsList()
    {
        Itineraries = new List<Itinerary>();
        TotalPerPage = 10;
        CurrentPage = 1;
        TotalResults = 0;
        TotalPages = 0;
    }

    protected override async Task OnParametersSetAsync()
    {
        await BindSearchResults();
    }

    private async Task BindSearchResults()
    {
        if (SearchCriteria != null)
        {
            var count = TotalPerPage;
            var start = CurrentPage * count;

            (int TotalCount, List<Itinerary>) returnVal;
            if (SearchCriteria.ItineraryId != null)
            {
                var itinerary = await cruiseService.GetItinerary(SearchCriteria.ItineraryId.Value);
                returnVal = new(1, new List<Itinerary> {itinerary});
            }
            else
            {
                returnVal = await cruiseService.SearchByCriteria(SearchCriteria, count, start);
            }
            
            if (!returnVal.Item2.Any())
            {
                Message= "No results were found. Please expand your search criteria.";
                Itineraries = new List<Itinerary>();
                TotalPages = 0;
                CurrentPage = 1;
                TotalResults = 0;
                return;
            }
            else
            {
                Message = string.Empty;
            }

            Itineraries = returnVal.Item2;

            TotalResults = returnVal.TotalCount;
            TotalPages = TotalResults / TotalPerPage;
        }
    }

    private async Task NumberResultsChanged(int totalPerPage)
    {
        TotalPerPage = totalPerPage;
        await BindSearchResults();
    }

    private async Task PageChanged(int page)
    {
        CurrentPage = page;
        await BindSearchResults();
    }
}
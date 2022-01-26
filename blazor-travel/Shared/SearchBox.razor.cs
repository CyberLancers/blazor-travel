using System.Net;
using System.Runtime.InteropServices;
using BlazorAssemblyTravel.Shared;
using BlazorAssemblyTravel.Shared.Models;
using Business.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace blazor_travel.Shared;

public partial class SearchBox
{
    [Inject]
    protected ICruiseService cruiseService { get; set; }
    protected List<Destination> Destinations { get; set; }
    protected List<CruiseLine> CruiseLines { get; set; }
    protected List<string> DepartureDates { get; set; }
    
    protected string destination { get; set; }
    protected string cruiseLine { get; set; }
    protected string cruiseLength { get; set; }
    protected string departure { get; set; }
    
    [Inject]
    protected NavigationManager navigationManager { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            Destinations = await cruiseService.GetDestinations();
            CruiseLines = await cruiseService.GetCruiseLines();
            DepartureDates = new List<string>();
            DateUtils.CreateDateList(DateTime.Now, 18).ForEach(d => DepartureDates.Add(d.ToString("MMMM yyyy")));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    protected void Search()
    {
        bool isFirst = true;
        var queryString = string.Empty;
        if (!string.IsNullOrEmpty(destination))
        {
            queryString += !isFirst ? "&" : "";
            queryString += "d=" + destination;
            isFirst = false;
        }
        if (!string.IsNullOrEmpty(cruiseLine))
        {
            queryString += !isFirst ? "&" : "";
            queryString += "c=" + cruiseLine;
            isFirst = false;
        }
        if (!string.IsNullOrEmpty(departure))
        {
            queryString += !isFirst ? "&" : "";
            queryString += "dt=" + departure;
            isFirst = false;
        }
        if (!string.IsNullOrEmpty(cruiseLength))
        {
            queryString += !isFirst ? "&" : "";
            queryString += "l=" + cruiseLength;
            isFirst = false;
        }
        navigationManager.NavigateTo("/results?" + queryString);
    }
}
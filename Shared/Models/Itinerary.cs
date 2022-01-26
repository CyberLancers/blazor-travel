namespace BlazorAssemblyTravel.Shared.Models;

public class Itinerary
{
    public int ItineraryId { get; set; }
    public string? ShipName { get; set; }
    public DateTime DateStart { get; set; }
    public string? Title { get; set; }
    public string? ShipImageUrl { get; set; }
    public string? CruiseLineImageUrl { get; set; }
    public int Nights { get; set; }
    public string Destinations { get; set; }
    public DateTime DateEnd { get; set; }
    public string? CruiseLineName { get; set; }
}
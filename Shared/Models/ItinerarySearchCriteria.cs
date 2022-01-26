namespace BlazorAssemblyTravel.Shared.Models;

public class ItinerarySearchCriteria
{
    public Destination? Region { get; set; }
    public CruiseLine? CruiseLine { get; set; }
    public string NumberDays { get; set; }
    public DateTime DepartureDate { get; set; }
    public int? ItineraryId { get; set; }
}
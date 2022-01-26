using BlazorAssemblyTravel.Shared.Models;

namespace Business.Services;

public interface ICruiseService
{
    Task<List<CruiseDeal>> GetCruiseDeals();
    Task<List<CruiseLine>> GetCruiseLines();
    Task<List<Destination>> GetDestinations();
    Task<CruiseLine?> GetCruiseLine(string cruiseLineId);
    Task<CruiseLine?> GetCruiseLineByName(string name);
    Task<Destination?> GetDestination(string destinationId);
    Task<Destination?> GetDestinationByName(string destination);
    Task<(int TotalCount, List<Itinerary>)> SearchByCriteria(ItinerarySearchCriteria searchCriteria, int? count, int? start);
    Task<decimal?> GetRate(int itineraryId, int roomTypeId);
    Task<Itinerary> GetItinerary(int itineraryId);
    Task<List<CruiseRate>> GetRates(int itineraryId, int roomTypeId);
}
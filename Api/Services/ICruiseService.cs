using BlazorAssemblyTravel.Shared.Models;

namespace BlazorAssemblyTravel.Api.Services;

public interface ICruiseService
{
    Task<List<CruiseDeal>> GetCruiseDeals();
    Task<List<CruiseLine>> GetCruiseLines();
    Task<List<Destination>> GetDestinations();
}
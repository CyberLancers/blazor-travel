using BlazorAssemblyTravel.Api.Data;
using BlazorAssemblyTravel.Api.Data.Repositories;
using BlazorAssemblyTravel.Shared.Models;

namespace BlazorAssemblyTravel.Api.Services;

public class CruiseService : ICruiseService
{
    private IUnitOfWork _unitOfWork;
    
    public CruiseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<CruiseDeal>> GetCruiseDeals()
    {
        var startDate = DateTime.Today.AddMonths(1);

        var statistics =
            await _unitOfWork.ItineraryStatisticRepository.Get(i => i.StartDate > startDate && i.StartPrice > 0, 
                i => i.OrderByDescending(t => t.DiscountPercent), 
                10, "Itinerary");

        var cruiseDeals = new List<CruiseDeal>();
        foreach (var statistic in statistics)
        {
            var cruiseDeal = new CruiseDeal
            {
                ItineraryId = statistic.ItineraryId,
                ItineraryTitle = statistic.Itinerary.Title ?? string.Empty,
                DateStart = statistic.Itinerary.DateStart,
                RoomType = statistic.RoomType.Description ?? string.Empty,
                StartPrice = statistic.StartPrice,
                EndPrice = statistic.EndPrice,
                Discount = Convert.ToInt32(statistic.DiscountPercent * 100)
            };
            cruiseDeals.Add(cruiseDeal);
        }

        return cruiseDeals;
    }
    
    public async Task<List<CruiseLine>> GetCruiseLines()
    {
        var lines = await _unitOfWork.CruiseLineRepository.Get();

        var cruiseLines = new List<CruiseLine>();
        foreach (var line in lines)
        {
            var cruiseLine = new CruiseLine()
            {
                Name = line.Name ?? String.Empty,
                SortOrder = line.SortOrder,
                IsFeatured = line.IsFeatured,
                CruiseLineId = line.CruiseLineId
            };
            cruiseLines.Add(cruiseLine);
        }

        return cruiseLines;
    }
    
    public async Task<List<Shared.Models.Destination>> GetDestinations()
    {
        var regions = await _unitOfWork.RegionRepository.Get();

        var destinations = new List<Destination>();
        foreach (var region in regions)
        {
            var destination = new Destination()
            {
                Name = region.Name ?? String.Empty,
                SortOrder = region.SortOrder ?? 0,
                RegionId = region.RegionId,
                ParentRegionId = region.ParentRegionId ?? 0,
                ListingName = region.ListingName ?? String.Empty
            };
            destinations.Add(destination);
        }

        return destinations;
    }
}
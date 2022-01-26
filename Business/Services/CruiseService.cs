using BlazorAssemblyTravel.Shared;
using BlazorAssemblyTravel.Shared.Models;
using Business.Data;
using Business.Data.DataObjects;
using Microsoft.EntityFrameworkCore;
using CruiseLine = BlazorAssemblyTravel.Shared.Models.CruiseLine;
using Destination = BlazorAssemblyTravel.Shared.Models.Destination;
using Itinerary = BlazorAssemblyTravel.Shared.Models.Itinerary;

namespace Business.Services;

public class CruiseService : ICruiseService
{
    //private IUnitOfWork _unitOfWork;
    private readonly IDbContextFactory<CruisePriceWatchContext> _contextFactory;

    public CruiseService(IDbContextFactory<CruisePriceWatchContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<CruiseDeal>> GetCruiseDeals()
    {
        List<ItineraryStatistic> statistics;
        var startDate = DateTime.Today.AddMonths(1);

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            statistics =
                await context.ItineraryStatistics.Where(i => i.StartDate > startDate && i.StartPrice > 0)
                    .OrderByDescending(t => t.DiscountPercent)
                    .Take(10)
                    .Include("Itinerary").ToListAsync();
        }


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
        List<Data.DataObjects.CruiseLine> lines;

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            lines =
                await context.CruiseLines.ToListAsync();
        }

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

    public async Task<CruiseLine?> GetCruiseLine(string cruiseLineStringId)
    {
        Data.DataObjects.CruiseLine? line;

        if (!Int32.TryParse(cruiseLineStringId, out var cruiseLineId))
            return null;

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            line =
                await context.CruiseLines.FirstOrDefaultAsync(c => c.CruiseLineId == cruiseLineId);
        }

        var cruiseLine = new CruiseLine()
        {
            Name = line.Name ?? String.Empty,
            SortOrder = line.SortOrder,
            IsFeatured = line.IsFeatured,
            CruiseLineId = line.CruiseLineId
        };

        return cruiseLine;
    }

    public async Task<CruiseLine?> GetCruiseLineByName(string cruiseLineName)
    {
        Data.DataObjects.CruiseLine? line;

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            line =
                await context.CruiseLines.FirstOrDefaultAsync(c =>
                    c.Name != null && EF.Functions.Like(c.Name, cruiseLineName));
        }

        var cruiseLine = new CruiseLine()
        {
            Name = line.Name ?? String.Empty,
            SortOrder = line.SortOrder,
            IsFeatured = line.IsFeatured,
            CruiseLineId = line.CruiseLineId
        };

        return cruiseLine;
    }

    public async Task<List<Destination>> GetDestinations()
    {
        List<Region> regions;

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            regions =
                await context.Regions.ToListAsync();
        }

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

    public async Task<Destination?> GetDestination(string destinationStringId)
    {
        Region region;

        if (!Int32.TryParse(destinationStringId, out var destinationId))
            return null;

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            region =
                await context.Regions.FirstOrDefaultAsync(r => r.RegionId == destinationId);
        }

        var destination = new Destination()
        {
            Name = region.Name ?? String.Empty,
            SortOrder = region.SortOrder ?? 0,
            RegionId = region.RegionId,
            ParentRegionId = region.ParentRegionId ?? 0,
            ListingName = region.ListingName ?? String.Empty
        };

        return destination;
    }

    public async Task<Destination?> GetDestinationByName(string destinationName)
    {
        Region region;

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            region =
                await context.Regions.FirstOrDefaultAsync(r =>
                    r.Name != null && EF.Functions.Like(r.Name, destinationName));
        }

        var destination = new Destination()
        {
            Name = region.Name ?? String.Empty,
            SortOrder = region.SortOrder ?? 0,
            RegionId = region.RegionId,
            ParentRegionId = region.ParentRegionId ?? 0,
            ListingName = region.ListingName ?? String.Empty
        };

        return destination;
    }

    public async Task<(int TotalCount, List<Itinerary>)> SearchByCriteria(ItinerarySearchCriteria searchCriteria,
        int? count, int? start)
    {
        var regionId = searchCriteria.Region?.RegionId ?? 0;
        var cruiseLineId = searchCriteria.CruiseLine?.CruiseLineId ?? 0;
        int minNights;
        int maxNights;

        switch (searchCriteria.NumberDays)
        {
            case "LessThree":
                minNights = 0;
                maxNights = 3;
                break;
            case "FourSeven":
                minNights = 4;
                maxNights = 7;
                break;
            case "EightPlus":
                minNights = 8;
                maxNights = 999;
                break;
            default:
                minNights = 0;
                maxNights = 999;
                break;
        }

        var startDate = DateUtils.GetStartOfMonth(searchCriteria.DepartureDate);
        var endDate = DateUtils.GetEndOfMonth(searchCriteria.DepartureDate);

        List<Data.DataObjects.Itinerary> itineraries;
        int totalCount = 0;

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            var itineraryQuery =
                context.Itineraries.Where(i =>
                        (i.Region.ParentRegionId == regionId || regionId == 0 || i.Region.RegionId == regionId) &&
                        (i.CruiseLineId == cruiseLineId || cruiseLineId == 0) && i.DateStart >= startDate &&
                        i.DateStart <= endDate && i.Nights >= minNights && i.Nights <= maxNights)
                    .Include("CruiseLine")
                    .Include("Ship")
                    .Include("ItineraryDestinations")
                    .Include("ItineraryDestinations.Destination").OrderBy(i => i.Nights).OrderBy(i => i.DateStart);

            totalCount = await itineraryQuery.CountAsync();
            itineraries = await itineraryQuery.Skip(start ?? 0).Take(count ?? 10).ToListAsync();
        }

        var resultItineraries = new List<Itinerary>();
        foreach (var itinerary in itineraries)
        {
            var resultItinerary = new Itinerary
            {
                Title = itinerary.Title,
                ItineraryId = itinerary.ItineraryId,
                ShipName = itinerary.Ship.Name,
                CruiseLineImageUrl = itinerary.CruiseLine.ImageUrl,
                DateStart = itinerary.DateStart,
                Nights = itinerary.Nights,
                ShipImageUrl = itinerary.Ship.ImageUrl
            };

            var destinations = itinerary.ItineraryDestinations;

            foreach (var destination in destinations)
            {
                resultItinerary.Destinations += destination.Destination.Name;
                if (destination.VisitOrder != destinations.Count())
                    resultItinerary.Destinations += ", ";
            }

            resultItineraries.Add(resultItinerary);
        }

        return (totalCount, resultItineraries);
    }

    public async Task<decimal?> GetRate(int itineraryId, int roomTypeId)
    {
        decimal? amount;

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            amount = await context.Rates.Where(r => r.ItineraryId == itineraryId && r.RoomTypeId == roomTypeId)
                .OrderByDescending(r => r.DateChecked)
                .Select(r => r.Amount).FirstOrDefaultAsync();
        }

        return amount;
    }

    public async Task<List<CruiseRate>> GetRates(int itineraryId, int roomTypeId)
    {
        List<Rate> rates;
        
        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            rates = await context.Rates.Where(r => r.ItineraryId == itineraryId && r.RoomTypeId == roomTypeId && r.Amount > 0)
                .OrderBy(r => r.DateChecked).ToListAsync();
        }

        var cruiseRates = new List<CruiseRate>();
        foreach (var rate in rates)
        {
            var cruiseRate = new CruiseRate()
            {
                RateId = rate.RateId,
                Amount = rate.Amount,
                DateChecked = rate.DateChecked
            };
            cruiseRates.Add(cruiseRate);
        }

        return cruiseRates;
    }
    
    public async Task<Itinerary> GetItinerary(int intineraryId)
    {
        var itinerary = new Business.Data.DataObjects.Itinerary();

        await using (var context = await _contextFactory.CreateDbContextAsync())
        {
            itinerary =
                await context.Itineraries.Where(i => i.ItineraryId == intineraryId)
                    .Include("CruiseLine")
                    .Include("Ship")
                    .Include("ItineraryDestinations")
                    .Include("ItineraryDestinations.Destination").FirstOrDefaultAsync();
        }

        var resultItinerary = new Itinerary
        {
            Title = itinerary.Title,
            ItineraryId = itinerary.ItineraryId,
            ShipName = itinerary.Ship.Name,
            CruiseLineImageUrl = itinerary.CruiseLine.ImageUrl,
            DateStart = itinerary.DateStart,
            DateEnd = itinerary.DateEnd,
            Nights = itinerary.Nights,
            ShipImageUrl = itinerary.Ship.ImageUrl,
            CruiseLineName = itinerary.CruiseLine.Name
        };

        var destinations = itinerary.ItineraryDestinations;

        foreach (var destination in destinations)
        {
            resultItinerary.Destinations += destination.Destination.Name;
            if (destination.VisitOrder != destinations.Count())
                resultItinerary.Destinations += ", ";
        }

        return resultItinerary;
    }
}

using BlazorAssemblyTravel.Api.Data.DataObjects;

namespace BlazorAssemblyTravel.Api.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class CruisePriceWatchContext : DbContext
    {
        public CruisePriceWatchContext(DbContextOptions<CruisePriceWatchContext> options)
            : base(options)
        { }

        public virtual DbSet<CruiseLine> CruiseLines { get; set; }
        public virtual DbSet<Destination> Destinations { get; set; }
        public virtual DbSet<Itinerary> Itineraries { get; set; }
        public virtual DbSet<ItineraryDestination> ItineraryDestinations { get; set; }
        public virtual DbSet<ItineraryStatistic> ItineraryStatistics { get; set; }
        public virtual DbSet<PriceResult> PriceResults { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Ship> Ships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Itinerary>()
                .HasMany(p => p.ItineraryStatistics)
                .WithOne(q => q.Itinerary)
                .IsRequired();
            
            modelBuilder.Entity<RoomType>()
                .HasMany(p => p.ItineraryStatistics)
                .WithOne(q => q.RoomType)
                .IsRequired();
        }
    }
}

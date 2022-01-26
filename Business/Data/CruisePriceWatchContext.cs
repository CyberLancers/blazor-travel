using Business.Data.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace Business.Data
{
    public partial class CruisePriceWatchContext : DbContext
    {
        public CruisePriceWatchContext(DbContextOptions<CruisePriceWatchContext> options)
            : base(options)
        { }

        public virtual DbSet<CruiseLine>? CruiseLines { get; set; }
        public virtual DbSet<Destination>? Destinations { get; set; }
        public virtual DbSet<Itinerary>? Itineraries { get; set; }
        public virtual DbSet<ItineraryDestination>? ItineraryDestinations { get; set; }
        public virtual DbSet<ItineraryStatistic>? ItineraryStatistics { get; set; }
        public virtual DbSet<PriceResult>? PriceResults { get; set; }
        public virtual DbSet<Rate>? Rates { get; set; }
        public virtual DbSet<Region>? Regions { get; set; }
        public virtual DbSet<RoomType>? RoomTypes { get; set; }
        public virtual DbSet<Ship>? Ships { get; set; }

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

            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.DiscountPercent)
                .HasPrecision(18, 4);
            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.EndPrice)
                .HasPrecision(18, 4);
            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.Intercept)
                .HasPrecision(18, 4);
            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.Max)
                .HasPrecision(18, 0);
            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.Mean)
                .HasPrecision(18, 4);
            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.Min)
                .HasPrecision(18, 0);
            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.Slope)
                .HasPrecision(18, 4);
            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.StartPrice)
                .HasPrecision(18, 4);
            modelBuilder.Entity<ItineraryStatistic>()
                .Property(p => p.StdDev)
                .HasPrecision(18, 4);
            modelBuilder.Entity<PriceResult>()
                .Property(p => p.PriceInside)
                .HasPrecision(9, 2);
            modelBuilder.Entity<PriceResult>()
                .Property(p => p.PriceOutside)
                .HasPrecision(9, 2);
            modelBuilder.Entity<PriceResult>()
                .Property(p => p.PriceSuite)
                .HasPrecision(9, 2);
            modelBuilder.Entity<PriceResult>()
                .Property(p => p.Pricebalcony)
                .HasPrecision(9, 2);
            modelBuilder.Entity<Rate>()
                .Property(p => p.Amount)
                .HasPrecision(9, 2);
        }
    }
}

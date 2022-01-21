using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAssemblyTravel.Api.Data.DataObjects
{
    [Table("ItineraryStatistics")]
    public partial class ItineraryStatistic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItineraryStatistic()
        {
            Itinerary = new Itinerary();
            RoomType = new RoomType();
        }

        [Key]
        public int StatisticsId { get; set; }
        
        public int ItineraryId { get; set; }
        
        public virtual Itinerary Itinerary { get; set; }
        
        public decimal Min { get; set; }
        
        public decimal Max { get; set; }
        
        public decimal Mean { get; set; }
        
        public decimal StdDev { get; set; }
        
        public decimal Slope { get; set; }
        
        public decimal Intercept { get; set; }
        
        public int Count { get; set; }
        
        public int NumChanges { get; set; }
        
        public string? CruiseLineName { get; set; }
        
        public string? RegionName { get; set; }
        
        public string? ShipName { get; set; }
        
        public int RoomTypeId { get; set; }
        
        public virtual RoomType RoomType { get; set; }
        
        public decimal StartPrice { get; set; }
        
        public decimal EndPrice { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public int Nights { get; set; }
        
        public decimal DiscountPercent { get; set; }
    }
}
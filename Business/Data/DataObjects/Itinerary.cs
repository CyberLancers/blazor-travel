using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Data.DataObjects
{
    [Table("Itinerary")]
    public partial class Itinerary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Itinerary()
        {
            Rates = new HashSet<Rate>();
            ItineraryDestinations = new HashSet<ItineraryDestination>();
            ItineraryStatistics = new HashSet<ItineraryStatistic>();
            Region = new Region();
            CruiseLine = new CruiseLine();
            Ship = new Ship();
        }

        [Key]
        public int ItineraryId { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int Regionid { get; set; }

        public virtual Region Region { get; set; }

        public int CruiseLineId { get; set; }

        public virtual CruiseLine CruiseLine { get; set; }

        public int ShipId { get; set; }

        public virtual Ship Ship { get; set; }

        public string? Notes { get; set; }

        public int Nights { get; set; }

        public DateTime CreationDate { get; set; }

        public string? ResultCode { get; set; }

        public DateTime LastChecked { get; set; }

        public string? Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rates { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItineraryDestination> ItineraryDestinations { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItineraryStatistic> ItineraryStatistics { get; set; }
    }
}
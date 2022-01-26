using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Data.DataObjects
{
    [Table("ItineraryDestination")]
    public partial class ItineraryDestination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItineraryDestination()
        {
            Itinerary = new Itinerary();
            Destination = new Destination();
        }
        [Key]
        public int ItineraryDestinationId { get; set; }

        public int ItineraryId { get; set; }
        
        public int DestinationId { get; set; }
        
        public int VisitOrder { get; set; }

        public virtual Itinerary Itinerary { get; set; }
        public virtual Destination Destination { get; set; }
    }
}
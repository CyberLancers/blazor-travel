using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Data.DataObjects
{
    [Table("Destination")]
    public partial class Destination
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Destination()
        {
            ItineraryDestinations = new HashSet<ItineraryDestination>();
            Region = new Region();
        }
        
        [Key]
        public int DestinationId { get; set; }

        [StringLength(255)] 
        public string? Name { get; set; }

        [StringLength(255)] 
        public string? Description { get; set; }

        public int RegionId { get; set; }
        
        public virtual Region Region { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItineraryDestination> ItineraryDestinations { get; set; }
    }
}
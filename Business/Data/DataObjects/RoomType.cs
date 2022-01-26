using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Data.DataObjects
{
    [Table("RoomType")]
    public partial class RoomType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomType()
        {
            Rates = new HashSet<Rate>();
            ItineraryStatistics = new HashSet<ItineraryStatistic>();
        }

        [Key]
        public int RoomTypeId { get; set; }

        [StringLength(50)]
        public string? Description { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rates { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItineraryStatistic> ItineraryStatistics { get; set; }
    }
}
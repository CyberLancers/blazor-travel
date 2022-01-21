using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAssemblyTravel.Api.Data.DataObjects
{
    [Table("Rate")]
    public partial class Rate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rate()
        {
            Itinerary = new Itinerary();
            RoomType = new RoomType();
        }

        [Key]
        public int RateId { get; set; }
        
        public int SearchId { get; set; }

        public int ItineraryId { get; set; }
        
        public int RoomTypeId { get; set; }
        
        public DateTime DateChecked { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public DateTime ModDate { get; set; }
        
        public string? CreatedBy { get; set; }
        
        public string? ModBy { get; set; }
        
        public virtual Itinerary Itinerary { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
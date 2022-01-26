using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Data.DataObjects
{
    [Table("Ship")]
    public partial class Ship
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ship()
        {
            
        }

        [Key]
        public int ShipId { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        [StringLength(255)]
        public string? Url { get; set; }
        
        [StringLength(255)]
        public string? ImageUrl { get; set; }
        
        [StringLength(255)]
        public string? ShipLink { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Data.DataObjects
{
    [Table("Region")]
    public partial class Region
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Region()
        {
            
        }

        [Key]
        public int RegionId { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }
        
        public string? Description { get; set; }
        
        public string? SearchId { get; set; }
        
        public int? SortOrder { get; set; }
        
        public int? ParentRegionId { get; set; }
        
        public string? ListingName { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAssemblyTravel.Api.Data.DataObjects
{
    [Table("CruiseLine")]
    public partial class CruiseLine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CruiseLine()
        {
            
        }

        [Key]
        public int CruiseLineId { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? Url { get; set; }
        
        [StringLength(255)]
        public string? LinkingName { get; set; }
        
        [StringLength(255)]
        public string? ImageUrl { get; set; }
        
        public int SortOrder { get; set; }
        
        public bool IsFeatured { get; set; }
    }
}

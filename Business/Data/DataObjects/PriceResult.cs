using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Data.DataObjects
{
    [Table("PriceResult")]
    public partial class PriceResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PriceResult()
        {
            
        }

        [Key]
        public int PriceResultId { get; set; }
        
        public int SearchResultId { get; set; }

        public decimal PriceInside { get; set; }
        
        public decimal PriceOutside { get; set; }
        
        public decimal Pricebalcony { get; set; }
        
        public decimal PriceSuite { get; set; }
        
        public string? Url { get; set; }
        
        public string? Site { get; set; }
        
        public string? Code { get; set; }
        
        public bool Direct { get; set; }
        
        public bool NoTaxesInc { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public string? CreatedBy { get; set; }
        
        public DateTime ModDate { get; set; }
        
        public string? ModBy { get; set; }
    }
}
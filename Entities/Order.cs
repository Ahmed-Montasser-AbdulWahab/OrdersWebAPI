using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }

        [RegularExpression(@"^ORDER_202[4-9]_[0-9]+$")]
        
        public string? OrderNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string? CustomerName { get; set; }


        [Required]
        public DateTime? OrderDate { get; set; }

        [Range(0, double.MaxValue)]
        public double? TotalAmount { get; set; }

        
        public virtual ICollection<OrderItem> Items { get; set; }
    }


}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaseStudyCFTry1.Models
{
    [Table("Order_items")]
    public class Order_items
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? ItemTotalPrice { get; set; }
        public virtual Orders? Orders { get; set; }
        public virtual Products? Products { get; set; }
    }
}

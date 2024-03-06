using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaseStudyCFTry1.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public virtual Products? Product { get; set; }
        public virtual Users? User { get; set; }
    }
}

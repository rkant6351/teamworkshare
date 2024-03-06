using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaseStudyCFTry1.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime? OrderDate { get; set; }= DateTime.Now;
        public string ShippingAddress { get; set; }
        public string? Status { get; set; }
        public decimal? Amount { get; set; }
        public virtual Users? User { get; set; }
        public virtual List<Order_items>? OrderItems { get; set; }
        public virtual List<Payments>? Payment { get; set; }
    }
}

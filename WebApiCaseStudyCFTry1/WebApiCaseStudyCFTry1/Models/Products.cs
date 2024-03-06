using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaseStudyCFTry1.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public int CategoryId { get; set; }
        public int SellerId { get; set; }
        public virtual Categories? Categories { get; set; }
        public virtual Sellers? Sellers { get; set; }
        public virtual List<Cart>? Carts { get; set; }
        public virtual List<Order_items>? Order_items { get; set; }
    }
}

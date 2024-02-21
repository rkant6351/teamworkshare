using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaseStudyCFTry1.Models
{
    [Table("Sellers")]
    public class Sellers
    {
        [Key]
        public int SellerId { get; set; }
        public string SellerEmail { get; set; }
        public string SellerFullName { get; set; }
        public string SellerPhoneNumber { get; set; }
        public string SellerAddress { get; set; }
        public string SellerPassword { get; set; }
        public string SellerGender { get; set; }
        public virtual List<Products>? Products { get; set; }
    }
}

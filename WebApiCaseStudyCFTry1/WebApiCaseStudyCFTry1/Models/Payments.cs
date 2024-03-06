using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaseStudyCFTry1.Models
{
    [Table("Payments")]
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public DateTime? PaymentDate { get; set; }= DateTime.Now;
        public string PaymentStatus { get; set; }
        public virtual Orders? Order { get; set; }
    }
}

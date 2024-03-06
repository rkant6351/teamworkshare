using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaseStudyCFTry1.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public virtual List<Cart>? Carts { get; set; }
        public virtual List<Orders>? Orders { get; set; }
    }
}

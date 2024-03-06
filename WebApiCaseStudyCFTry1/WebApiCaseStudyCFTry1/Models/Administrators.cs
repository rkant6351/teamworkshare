using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCaseStudyCFTry1.Models
{
    [Table("Administrators")]
    public class Administrators
    {
        [Key]
        public int AdminId { get; set; }
        public string AdminEmail { get; set; }
        public string AdminFullName { get; set; }
        public string AdminPhoneNumber { get; set; }
        public string AdminPassword { get; set; }
    }
}

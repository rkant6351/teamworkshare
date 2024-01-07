using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom_Application.Model_Classes
{
    internal class Products
    {
        public int product_id {  get; set; }
        public string name {  get; set; }
        public decimal price {  get; set; }
        public string description {  get; set; }
        public int stockQuantity {  get; set; }
    }
}

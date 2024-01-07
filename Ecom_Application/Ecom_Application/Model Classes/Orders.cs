using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ecom_Application.Model_Classes
{
    internal class Orders
    {
        static int order_id { get; set; }
        static int customer_id { get; set; }
        static DateTime order_date { get; set; }
        static double total_price { get; set; }
        static string shipping_address { get; set; }
    }
}

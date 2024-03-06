﻿using System;
using System.Collections.Generic;

namespace WebApiDBFirstCaseStudyTRY1.Models
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? ItemTotalPrice { get; set; }

        public virtual Order? Order { get; set; } = null!;
        public virtual Product? Product { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DemoPagingAndCart.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

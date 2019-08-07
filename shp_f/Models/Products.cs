using System;
using System.Collections.Generic;

namespace shp_f.Models
{
    public partial class Products
    {
        public Products()
        {
            Cart = new HashSet<Cart>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int ProductPiece { get; set; }
        public double ProductPrice { get; set; }
        public string ProductUrl { get; set; }

        public Categories Category { get; set; }
        public ICollection<Cart> Cart { get; set; }
    }
}

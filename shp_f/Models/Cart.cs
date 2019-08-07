using System;
using System.Collections.Generic;

namespace shp_f.Models
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public Guid ShoppingId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public double ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public bool IsDone { get; set; }

        public Products Product { get; set; }
        public Users User { get; set; }
    }
}

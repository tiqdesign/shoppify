using System;
using System.Collections.Generic;

namespace shp_f.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Categories Category { get; set; }
        public Categories InverseCategory { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}

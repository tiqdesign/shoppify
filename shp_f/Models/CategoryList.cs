using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shp_f.Models
{
    public class CategoryList
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int ProductPiece { get; set; }
        public double  ProductPrice { get; set; }
        public string  ProductUrl { get; set; }
    }
}

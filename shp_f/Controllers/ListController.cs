using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shp_f.Func;

namespace shp_f.Controllers
{
    public class ListController : Controller
    {
        DbFunc _func = DbFunc.getInstance();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UrunIncele(int ProductID)
        {
            var product = _func.GetProduct(ProductID);
            return View(product);
        }

        [HttpGet]
        public IActionResult UrunListele()
        {
            var liste = _func.GetAllProducts();
            return View(liste);
        }
    }
}
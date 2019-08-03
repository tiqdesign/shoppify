using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            if (HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                var product = _func.GetProduct(ProductID);
                return View(product);
            }

        }

        [HttpPost]
        public IActionResult UrunListeleK(string category)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                 return RedirectToAction("HomePage", "Home"); 
            }
            else
            {
           
                var liste = _func.GetListWithCategory(category);
                return View(liste);
            }
        }


    }
}
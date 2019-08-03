using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shp_f.Func;
using shp_f.Models;


namespace shp_f.Controllers
{
    public class HomeController : Controller
    {
        DbFunc _func = DbFunc.getInstance();

        public IActionResult HomePage()
        {
            return View();
        }


        public ActionResult AutoComplete(string ct)
        {
            var liste = _func.GetCategory();
            var data = liste.Where(c => c.CategoryName.StartsWith(ct.First().ToString().ToUpper() + ct.Substring(1))).Select(c => c.CategoryName).ToList();
            return Json(data);
        }

    }
}
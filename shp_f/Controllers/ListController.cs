using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
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
        [HttpPost]
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

        public void SepeteEkle(int ProductID)
        {
            int userid = HttpContext.Session.GetInt32("UserId").Value;
            Guid shpid = Guid.Parse(HttpContext.Session.GetString("ShoppingId"));
            _func.addToCart(ProductID, userid, 1 ,shpid);
          
        }

        [HttpPost]
        public IActionResult UrunListeleK(string ct)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                 return RedirectToAction("HomePage", "Home"); 
            }
            else
            {
                var liste = _func.GetListWithCategory(ct);
                return View(liste);
            }
        }

        public IActionResult SepetGörüntüle()
        {
            Guid id = Guid.Parse(HttpContext.Session.GetString("ShoppingId"));
            var liste = _func.GetCartWithShoppingId(id);
            string tutar = _func.CalculateAmount(id);
            ViewData.Add("Toplam Tutar",tutar);
            return View(liste);
        }

        public IActionResult SepettenKaldir(int ProductID)
        {
            Guid shpid = Guid.Parse(HttpContext.Session.GetString("ShoppingId"));
            _func.DeleteProductFromCart(ProductID,shpid);
            return RedirectToAction("SepetGörüntüle");
        }

        public void SepetiOnayla()
        {
             Guid shpid = Guid.Parse(HttpContext.Session.GetString("ShoppingId"));
            _func.ConfirmPurchase(shpid);
        }

        public IActionResult SepetiGuncelle(int ProductID, int amount)
        {
            Guid shpid = Guid.Parse(HttpContext.Session.GetString("ShoppingId"));
            _func.UpdateCart(amount, ProductID,shpid);
            return RedirectToAction("SepetGörüntüle");
        }
    }
}
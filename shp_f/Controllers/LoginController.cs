using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using shp_f.Func;
using shp_f.Models;

namespace shp_f.Controllers
{
    public class LoginController : Controller
    {
        //Singleton olduğu için
        DbFunc _func = DbFunc.getInstance();

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult LoginPage(string username, string password)
        {
            var user = _func.GetUser(username,password);
            //boş değilse giriş yap sayfaya yönlendir boş işe bilgileri kontrol etsin.
            if (user == null)
            {
                return View();
            }
            else
            {
                HttpContext.Session.SetString("Username",username);
                return RedirectToAction("HomePage", "Home");
            }
        }

        public IActionResult LogoutPage()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("HomePage","Home");
        }


    }
}
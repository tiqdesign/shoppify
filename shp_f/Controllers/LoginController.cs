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
                HttpContext.Session.SetString("Username",user.UserFullName);
                HttpContext.Session.SetInt32("UserId",user.UserId);
                Guid shpid = Guid.NewGuid();
                //Burada oluşturduk çıkış yaparken bunu sil 
                HttpContext.Session.SetString("ShoppingId", shpid.ToString());
                return RedirectToAction("HomePage", "Home");
            }
        }

        public IActionResult LogoutPage()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("HomePage","Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult SignUp(Users u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }
            else
            {
                _func.CreateUser(u);
                return RedirectToAction("HomePage", "Home");
            }
        }



    }
}
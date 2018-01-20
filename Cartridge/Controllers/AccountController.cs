using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cartridge.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(p000048 model)
        {
            p000048 user = null;
            using (b1cakEntities db = new b1cakEntities())
            {
                user = db.p000048.FirstOrDefault(u => u.name == model.name && u.password == model.password);
            }
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(model.name, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Неверный логин или пароль";
                return View();
            }
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cartridge.Controllers
{
    public class HomeController : Controller
    {
        b1cakEntities db = new b1cakEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowInstall()
        {
            ViewBag.InstalledCartridges = db.p000052.Where(x => x.kod_p000051 == 3).ToList();
            return PartialView();
        }

        public ActionResult ShowRefill()
        {
            ViewBag.RefillingCartridges = db.p000052.Where(x => x.kod_p000051 == 7).ToList();

            return PartialView();
        }

        public ActionResult ShowBox()
        {
            ViewBag.BoxCartridges = db.p000052.Where(x => x.kod_p000051 == 6).ToList();
            return PartialView();
        }

        public ActionResult ShowCupboard()
        {
            ViewBag.CupboardCartridges = db.p000052.Where(x => x.kod_p000051 == 5).ToList();
            return PartialView();
        }

        public ActionResult DeviceReport()
        {
            ViewBag.Devices = db.p000047.OrderBy(x=>x.kod_p000044).ToList();
            return View();
        }

        public ActionResult FindCartridge(int cartridgeID)
        {
            List<p000052> cartridge = db.p000052.Where(x=>x.kod==cartridgeID).ToList();
            if (cartridge.LongCount() > 0)
            {
                ViewBag.Cartridge = cartridge;
            }
            else
            {
                ViewBag.Cartridge = null;
            }
            return PartialView(cartridge);
        }
    }
}

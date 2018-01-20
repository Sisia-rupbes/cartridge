using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace Cartridge.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        b1cakEntities db = new b1cakEntities();
        public ActionResult Index()
        {
            ViewBag.Departments = db.p000044.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ShowDevices(int departmentID)
        {
            List<p000047> devices = db.p000047.Where(x => x.kod_p000044 == departmentID).ToList();
            ViewBag.Devices = devices;
            return PartialView();
        }
        [HttpPost]
        public string AddRequest(int deviceID)
        {
            db.AddRequest(deviceID);
            p000047 device = db.p000047.Find(deviceID);
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("sisia@rupbes.by");
                mail.To.Add(new MailAddress("sisia@rupbes.by"));
                mail.Subject = "Заявка на замену картриджа";
                mail.Body = "Поступила заявка с отдела - "+device.p000044.department.ToString()+" на устройство печати - "+device.p000045.device_brand.ToString()+" "+device.p000045.device_model+" инв.№ - "+device.number.ToString();
                SmtpClient client = new SmtpClient();
                client.Host = "mail.rupbes.by";
                client.Port = 25;
                client.EnableSsl = false;
                client.Credentials = new NetworkCredential("sisia", "sisia1");
                client.Send(mail);
                mail.Dispose();
            }
            
            

            return "Запрос отправлен";
        }

        
    }
}
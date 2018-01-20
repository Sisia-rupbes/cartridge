using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Cartridge.Models;

namespace Cartridge.Controllers
{
    [Authorize]
    public class DirectoryController : Controller
    {
        // GET: Directory
        WordReport wr = new WordReport();
        b1cakEntities db = new b1cakEntities();
        static int depID;
        static int devID;
        static byte[] install_request;
        static byte[] refill_request;
        
        public ActionResult Index()
        {
            ViewBag.Devices = db.p000045.ToList();
            ViewBag.Departments = db.p000044.ToList();
            ViewBag.Cartridges = db.p000049.ToList();
            return View();
        }

        public ActionResult Physical()
        {
            ViewBag.Devices = db.p000045.ToList();
            ViewBag.Departments = db.p000044.ToList();
            ViewBag.Cartridges = db.p000049.ToList();
            return View();
        }

        public ActionResult Cartridges()
        {
            ViewBag.Cartridges = db.p000052.ToList();
            ViewBag.Models = db.p000049.ToList();
            ViewBag.Statuses = db.p000051.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DeleteCartridge(int id)
        {
            try
            {
                p000052 cartridge = db.p000052.Find(id);
                db.p000052.Remove(cartridge);
                db.SaveChanges();
                ViewBag.Message = "База обновлена";
            }
            catch
            {
                ViewBag.Message = "Данного картриджа уже нет в базе";
            }
            return PartialView("Sucsess");
        }
        [HttpPost]
        public ActionResult ChangeStatus(int cartridgeID, int statusID, int deviceID = -1)
        {
            ViewBag.Devices = db.p000047.ToList();
            ViewBag.Departments = db.p000044.ToList();
            ViewBag.Models = db.p000045.ToList();
            ViewBag.Devices = db.p000047.ToList();
            FitDevice fit_device = new FitDevice();
            if (deviceID == -1)
            {
                if (statusID == 3)
                {
                    try
                    {
                        ViewBag.FitDevices = fit_device.GetDevices(cartridgeID);
                        return PartialView("AddInputStatus");//Добавляем в форму еще инпут с deviceID +

                    }
                    catch
                    {
                        ViewBag.Message = "Данного картриджа уже нет в базе";
                        return PartialView("Sucsess");
                    }
                }
                else
                {
                    try
                    {
                        db.CartridgeChangeStatus(cartridgeID, statusID);
                        ViewBag.Message = "База обновлена";
                    }
                    catch
                    {
                        ViewBag.Message = "Данного картриджа уже нет в базе";
                    }
                    return PartialView("Sucsess");//Нужно вызвать функцию бд, которая изменит таблцу 52 для этого cartridgeID и запишет данные в 53 таблицу(там тригер, ничего не нужно)+
                }
            }
            else
            {
                if (statusID == 3)
                {
                    try
                    {
                        db.CartridgeChangeStatus(cartridgeID, statusID);
                        p000054 install = new p000054();
                        install.kod_p000052 = cartridgeID;
                        install.kod_p000047 = deviceID;
                        install.date = DateTime.Now;
                        db.p000054.Add(install);
                        db.SaveChanges();
                        ViewBag.Message = "База обновлена";
                    }
                    catch
                    {
                        ViewBag.Message = "Данного картриджа уже нет в базе";
                    }
                    return PartialView("Sucsess");//Нужно вызвать функцию бд, которая изменит таблицу 52 для этого cartridgeID и запишет данные в таблицу 54+
                }
                else
                {
                    ViewBag.Message = "Неверный ввод данных";
                    return PartialView("Sucsess");//Нужно вернуть ошибку о неверном вводе данных
                }
            }



        }

        public ActionResult Devices()
        {
            ViewBag.Devices = db.p000047.OrderBy(x=>x.kod_p000044).ToList();
            ViewBag.Departments = db.p000044.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult EditDevice(p000047 device)
        {
            p000047 db_device = db.p000047.Find(device.kod);
            db_device.kod_p000044 = device.kod_p000044;
            db_device.number = device.number;
            db.Entry(db_device).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.Message = "База обновлена";
            return PartialView("Sucsess");
        }

        [HttpPost]
        public ActionResult DeleteDevice(int deviceID,int cartridgeID)
        {
            if (cartridgeID != 0)
            {
                try
                {
                    p000047 device = db.p000047.Find(deviceID);
                    p000052 cartridge = db.p000052.Find(cartridgeID);
                    cartridge.kod_p000051 = null;
                    db.Entry(cartridge).State = EntityState.Modified;
                    db.p000047.Remove(device);
                    db.SaveChanges();
                    ViewBag.Message = "База обновлена. Картриджу, который был установлен на данном устройстве назначен статус - NULL";
                }
                catch
                {
                    ViewBag.Message = "Данного картриджа уже нет в базе";
                }
                
            }
            else
            {
                p000047 device = db.p000047.Find(deviceID);
                db.p000047.Remove(device);
                try
                {
                    db.SaveChanges();
                    ViewBag.Message = "База обновлена.";
                }
                catch
                {
                    ViewBag.Message = "Данного устройства уже нет в базе";
                }
                
            }
            return PartialView("Sucsess");
        }

        public ActionResult AllCatModels()
        {
            ViewBag.AllCatModels = db.p000049.ToList();
            ViewBag.AllDevModels = db.p000045.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult EditCatModel(p000049 cat_model, int[] fit_devices )
        {
            p000049 db_cat_model = db.p000049.Find(cat_model.kod);
            db_cat_model.cartridge_brand = cat_model.cartridge_brand;
            db_cat_model.cartridge_model = cat_model.cartridge_model;
            db_cat_model.p000045.Clear();
            if(fit_devices != null)
            {
                foreach(p000045 dev_model in db.p000045.Where(x=> fit_devices.Contains(x.kod)))
                {
                    db_cat_model.p000045.Add(dev_model);
                }
            }
            db.Entry(db_cat_model).State = EntityState.Modified;
            try
            {
                
                db.SaveChanges();
                ViewBag.Message = "База обновлена";
            }
            catch
            {
                ViewBag.Message = "Повторяющиеся записи недопустимы";
            }
            return PartialView("Sucsess");
        }
        [HttpPost]
        public ActionResult DeleteCatModel(int id)
        {
            p000049 cat_model = db.p000049.Find(id);
            if (cat_model == null)
            {
                ViewBag.Message = "Данного картриджа уже нету в базе";
                return PartialView("Sucsess");
            }
            else
            {
                try
                {
                    db.p000049.Remove(cat_model);
                    db.SaveChanges();
                    ViewBag.Message = "База обновлена";
                }
                catch
                {
                    ViewBag.Message = "Невозможно удалить модель, пока не удалены картриджи этой модели";
                }
                return PartialView("Sucsess");
            }
            
        }

        public ActionResult AllDevModels()
        {
            ViewBag.AllCatModels = db.p000049.ToList();
            ViewBag.AllDevModels = db.p000045.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult EditDevModel(p000045 dev_model, int[] fit_cartridges)
        {
            p000045 db_dev_model = db.p000045.Find(dev_model.kod);
            db_dev_model.device_brand = dev_model.device_brand;
            db_dev_model.device_model = dev_model.device_model;
            db_dev_model.p000049.Clear();
            if (fit_cartridges != null)
            {
                foreach (p000049 cat_model in db.p000049.Where(x => fit_cartridges.Contains(x.kod)))
                {
                    db_dev_model.p000049.Add(cat_model);
                }
            }
            db.Entry(db_dev_model).State = EntityState.Modified;
            try
            {

                db.SaveChanges();
                ViewBag.Message = "База обновлена";
            }
            catch
            {
                ViewBag.Message = "Повторяющиеся записи недопустимы";
            }
            return PartialView("Sucsess");
        }
        [HttpPost]
        public ActionResult DeleteDevModel(int id)
        {
            p000045 dev_model = db.p000045.Find(id);
            if (dev_model == null)
            {
                ViewBag.Message = "Данного устройства уже нету в базе";
                return PartialView("Sucsess");
            }
            else
            {
                try
                {
                    db.p000045.Remove(dev_model);
                    db.SaveChanges();
                    ViewBag.Message = "База обновлена";
                }
                catch
                {
                    ViewBag.Message = "Невозможно удалить модель, пока не удалены устройства этой модели";
                }
                return PartialView("Sucsess");
            }
        }

        public ActionResult AllDepartments()
        {
            ViewBag.AllDepartments = db.p000044.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult EditDepartment(int kod, string department)
        {
            p000044 db_department = db.p000044.Find(kod);
            db_department.department = department;
            db.Entry(db_department).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
                ViewBag.Message = "База обновлена";
            }
            catch
            {
                ViewBag.Message = "Повторяющиеся значения недопустимы";
            }
            return PartialView("Sucsess");
        }

        public string AddDepartment(string new_department)
        {
            string answer = "Поля не заполнены";
            if (new_department != "")
            {
                using (b1cakEntities db = new b1cakEntities())
                {
                    try
                    {
                        p000044 department = new p000044();
                        department.department = new_department;
                        db.p000044.Add(department);
                        db.SaveChanges();
                        answer = "Справочник обновлен";
                    }
                    catch
                    {
                        answer = "Такой отдел уже есть в справочнике";
                    }

                }   
            }
            return answer;
        }//Добавляет новый отдел

        public string AddDeviceModel(string device_brand, string device_model, int[] fit_cartridge)
        {
            string answer = "Поля не заполнены";
            if (device_brand != "" && device_model != "")
            {
                using(b1cakEntities db = new b1cakEntities())
                {
                    try
                    {
                        p000045 device = new p000045();
                        device.device_brand = device_brand;
                        device.device_model = device_model;
                        foreach (var item in db.p000049.Where(a => fit_cartridge.Contains(a.kod)))//записывает в item объект таблицы с девайсами, если в нем код равен значению fit_device
                        {
                            device.p000049.Add(item);
                        }
                        db.p000045.Add(device);
                        db.SaveChanges();
                        answer = "Справочник обновлен";
                    }
                    catch
                    {
                        answer = "Такое устройство уже есть в справочнике";
                    }
                }
            }
            return answer;
        }//Добавляет новый девайс

        public string AddCartridgeModel(string cartridge_brand, string cartridge_model)
        {
            string answer = "Поля не заполнены";
            if (cartridge_brand!="" && cartridge_model != "")
            {
                using (b1cakEntities db = new b1cakEntities())
                {
                    try
                    {
                        p000049 cartridge = new p000049();
                        cartridge.cartridge_brand = cartridge_brand;
                        cartridge.cartridge_model = cartridge_model;
                        db.p000049.Add(cartridge);
                        db.SaveChanges();
                        answer = "Справочник обновлен";
                    }
                    catch
                    {
                        answer = "Такой картридж уже есть в справочнике";
                    }
                }
            }
            return answer;
        }//добавляет новый картридж

        public string AddStatus(string new_status)
        {
            string answer = "Поля не заполнены";
            if (new_status != "")
            {
                using (b1cakEntities db = new b1cakEntities())
                {
                    try
                    {
                        p000051 status = new p000051();
                        status.status = new_status;
                        db.p000051.Add(status);
                        db.SaveChanges();
                        answer = "Справочник обновлен";
                    }
                    catch
                    {
                        answer = "Такое состояние уже есть в справочнике";
                    }
                }
            }
            return answer;
        }

        public ActionResult AddDevice(p000047 device)
        {
        db.p000047.Add(device);
        db.SaveChanges();
        ViewBag.Message = "База обновлена";
        return PartialView("Sucsess");
        }

        public string AddCartridge(int modelID)
        {
            string answer="";
            using(b1cakEntities db = new b1cakEntities())
            {
                p000052 cartridge = new p000052();
                cartridge.kod_p000049 = modelID;
                db.p000052.Add(cartridge);
                db.SaveChanges();
                answer = "Картридж №" + cartridge.kod.ToString() + " добавлен";
            }
            return answer;
        }

        

        public ActionResult InstallPage()
        {
            depID = -2;
            devID = -2;
            ViewBag.Departments = db.p000044.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult InstallCartridge(int departmentID, int deviceID=-1, int cartridgeID=-1)
        {
            List<p000047> devices = db.p000047.Where(x => x.kod_p000044 == departmentID).ToList();
            FitDevice fit_cartridges = new FitDevice();
            ViewBag.Devices = devices;
            if (deviceID == -1 || depID != departmentID)
            {
                depID = departmentID;
                return PartialView("ShowDevice");//Если не передано deviceID, то добавляем один инпут с выбором девайса для этого отдела+
            }
            else
            {
                if (cartridgeID == -1 || devID != deviceID)
                {
                    devID = deviceID;
                    ViewBag.Cartridges = fit_cartridges.GetCatridges(deviceID);
                    ViewBag.DeviceID = deviceID;
                    return PartialView("ShowDevicesAndCartridges");//Если передан девайсИД, но не передан картриджИД, то добавляем к изначальной форме два инпута(с выбором девайса для этого отдела и выбором картриджа для этого девайса)+
                }
                else
                {
                    List<p000054> install_list = db.p000054.Where(x => x.kod_p000047 == deviceID).ToList();//Список всех установленных картриджей на это устройство
                    p000054 last_installed_cartridge = install_list.FirstOrDefault(x => x.date == install_list.Max(z => z.date));
                    p000054 install = new p000054();
                    int licID = cartridgeID;
                    if (last_installed_cartridge != null)
                    {
                        licID = last_installed_cartridge.kod_p000052;
                        db.CartridgeChangeStatus(last_installed_cartridge.kod_p000052, 6);//Ложим картридж, который был установлен на этом девайсе в коробку
                    }
                    //wr.GetRequest(departmentID, deviceID, licID, Server.MapPath("~/Content/install_request1.docx"), Server.MapPath("~/Content/install_request.docx"));
                    OpenXML instReq = new OpenXML();
                    install_request = instReq.CreatePackageAsBytes(departmentID, deviceID, licID);
                    db.CartridgeChangeStatus(cartridgeID, 3);//Устанавливаем картридж
                    install.kod_p000052 = cartridgeID;
                    install.kod_p000047 = deviceID;
                    install.date = DateTime.Now;
                    db.p000054.Add(install);
                    db.SaveChanges();//Добавялем запись в 54 таблицу
                    return PartialView("InstallCartridgeReport");//Если переданы значения с формы, то нужно найти картриджИД с таким девайсИД и максимальной датой в таблице 54, после чего для этого картриджа в таблице 52 изменить значение статусИД на !в коробке!. Потом для для картриджИД из формы нужно изменить статусИД на установлен и записать в таблицу 54 новую запись+
                }
            }

        }

        public FileResult InstallCartridgeReport()
        {
            //byte[] file = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/install_request1.docx"));

            return File(install_request, "application/word","install_request.docx");
        }

        public ActionResult RefillingPage()
        {
            ViewBag.VoidCartridges = db.p000052.Where(x => x.kod_p000051 == 6).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult RefillCartridge(int[] cartridgesID)
        {
            List<p000052> void_cartridges = new List<p000052>();
            if (cartridgesID!=null)
            {
                foreach (int id in cartridgesID)
                {
                    void_cartridges.Add(db.p000052.Find(id));
                }
                List<p000049> models = new List<p000049>();
                foreach (p000052 cart in void_cartridges)
                {
                    models.Add(cart.p000049);
                }
                List<p000049> dif_models = models.Distinct().ToList();
                List<int> count_models = new List<int>();
                foreach (p000049 model in dif_models)
                {
                    count_models.Add(models.Where(x => x.kod == model.kod).Count());
                }
                int i = 0;

                List<ModelCounter> listModelCounter = new List<ModelCounter>();
                foreach (p000049 model in dif_models)
                {
                    ModelCounter modelCounter = new ModelCounter();
                    modelCounter.Model = dif_models[i];
                    modelCounter.Count = count_models[i];
                    listModelCounter.Add(modelCounter);
                    i++;
                }
                //wr.GetRefill(listModelCounter, Server.MapPath("~/Content/refill_request1.docx"), Server.MapPath("~/Content/refill_request.docx"));//Формирование отчета в ворд
                OpenXMLRefill refReq = new OpenXMLRefill();
                refill_request = refReq.CreatePackageAsBytes(listModelCounter);
                foreach (int id in cartridgesID)
                {
                    db.CartridgeChangeStatus(id, 7);
                }
                return PartialView("RefillCartridgeReport");//Нужно написать код по обновлению всех картриджей с массива на новый статус !в заправке!
            }
            else
            {
                ViewBag.Message = "Cписок пуст";
                return PartialView("Sucsess");
            }
            
        }

        public FileResult RefillCartridgeReport()
        {
            //byte[] file = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/refill_request1.docx"));

            return File(refill_request, "application/word", "refill_request.docx");
        }

        public ActionResult ReturnPage()
        {
            ViewBag.FullCartridges = db.p000052.Where(x => x.kod_p000051 == 7).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ReturnCartridge(int[] cartridgesID)
        {
            if (cartridgesID != null)
            {
                foreach (int id in cartridgesID)
                {
                    db.CartridgeChangeStatus(id, 5);
                }
                ViewBag.Message = "База обновлена. Положите заправленные картриджи в шкаф";
                return PartialView("Sucsess");
            }
            else
            {
                ViewBag.Message = "Список пуст";
                return PartialView("Sucsess");
            }
        }
    }
}
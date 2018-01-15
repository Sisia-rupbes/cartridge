using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EasyDox;
using System.Diagnostics;


namespace Cartridge.Models
{
    public class WordReport
    {
        b1cakEntities db = new b1cakEntities();

        public void GetRequest(int departmentID, int deviceID, int cartridgeID, string outputPath, string inputPath)
        {
            p000044 department = db.p000044.Find(departmentID);
            p000052 cartridge = db.p000052.Find(cartridgeID);
            p000047 device = db.p000047.Find(deviceID);
            var engine = new Engine();
            var fieldValues = new Dictionary<string, string>
                {
                    {"<device_name>", device.p000045.device_brand.ToString()+" "+device.p000045.device_model.ToString()},
                    {"<device_number>",device.number.ToString() },
                    {"<cartridge_number>", cartridge.kod.ToString()},
                    {"<cartridge_name>", cartridge.p000049.cartridge_brand.ToString()+" "+cartridge.p000049.cartridge_model.ToString()},
                    {"<department_name>",department.department.ToString()},
                    {"<date>", DateTime.Now.ToShortDateString ()}
                };
            var errors = engine.Merge(inputPath, fieldValues, outputPath);
            foreach (var error in errors)
            {
                    error.Accept(new ErrorToRussianString());
            }
        }

        public void GetRefill(List<ModelCounter> listModelCounter, string outputPath, string inputPath)
        {
            var engine = new Engine();
            var fieldValues = new Dictionary<string, string> { };
            int i = 0;
            int? countAll=0;

            ModelCounter[] massiveModelCounter = new ModelCounter[15];
            p000049 voidModel = new p000049()
            {
                cartridge_brand = "",
                cartridge_model = ""
            };
            
            for (int u = 0; u < massiveModelCounter.Length; u++)
            {
                massiveModelCounter[u] = new ModelCounter()
                {
                    Model = voidModel,
                    Count = 0
                   
                };
                if (u < listModelCounter.LongCount())
                {
                    massiveModelCounter[u] = listModelCounter[u];
                }
            }
            foreach (ModelCounter modelCounter in massiveModelCounter)
            {
                fieldValues.Add("field" + i , modelCounter.Model.cartridge_brand.ToString() + " " + modelCounter.Model.cartridge_model.ToString());
                if (modelCounter.Count != 0)
                {
                    fieldValues.Add("count" + i, modelCounter.Count.ToString());
                }
                else
                {
                    fieldValues.Add("count" + i, "");
                }
                countAll += modelCounter.Count;
                i++;
            }
            fieldValues.Add("countAll", countAll.ToString());
            fieldValues.Add("date", DateTime.Now.ToShortDateString());  
            var errors = engine.Merge(inputPath, fieldValues, outputPath);
            foreach (var error in errors)
            {
                error.Accept(new ErrorToRussianString());
            }
        }
    }
}
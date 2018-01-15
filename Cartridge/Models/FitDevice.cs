using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cartridge.Models
{
    public class FitDevice
    {
        b1cakEntities db = new b1cakEntities();
        public List<p000047> GetDevices(int cartridgeID)
        {
            p000052 test = db.p000052.Find(cartridgeID);//Картриджа с таким ID
            p000049 test1 = db.p000049.Find(test.kod_p000049);//Модель картриджа с таким ID картриджа
            List<p000045> test2 = test1.p000045.ToList();//Список всех моделей девайсов для модели картриджа с таким ид картриджа
            List<p000047> test3 = new List<p000047>();
            foreach (p000045 item1 in test2)
            {
                foreach (p000047 item2 in item1.p000047)
                {
                    test3.Add(item2);
                }
            }
            return test3;
        }
        public List<p000052> GetCatridges(int deviceID)
        {
            p000047 device = db.p000047.Find(deviceID);//Сам девайс с таким ИД
            p000045 device_model = db.p000045.Find(device.kod_p000045);//Модель девайса с таким ID девайса
            List<p000049> cartridge_models = device_model.p000049.ToList();//Список всех моделей картриджей с таким ид девайса
            List<p000052> cartridges = new List<p000052>();//Создаем новый список объектов класса таблицы 52
            foreach (p000049 cartridge_model in cartridge_models)
            {
                foreach (p000052 cartridge in cartridge_model.p000052)
                {
                    cartridges.Add(cartridge);
                }
            }//Добавляем в список все подходящие картриджи
            List<p000052> ciw = cartridges.Where(x => x.kod_p000051 == 5).ToList();//оставляем только те, что в шкафу
            return ciw;
        }//Возвращает список картриджей из 52 таблицы, которые подходят девайсу с deviceID
    }
}
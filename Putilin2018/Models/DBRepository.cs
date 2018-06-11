using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Putilin2018.Models;

namespace Putilin2018.Models
{
    public class DBRepository
    {
        #region Stuff
        private MyDatabaseEntities db;
        private bool disposed = false;
        public DBRepository(MyDatabaseEntities context)
        {
            if (context == null) this.db = new MyDatabaseEntities();
            else this.db = context;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                if (disposing)
                    db.Dispose();

            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Voditel
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Voditel> GetVoditels()
        {
            var res = new List<Voditel>();
            var key = "b_Voditels";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Voditel>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Voditel.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Voditel GetVoditel(int ID)
        {
            var res = new Voditel();
            var key = "b_Voditels_Voditel" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Voditel)CacheManager.Cache[key];
            }
            else
            {
                res = db.Voditel.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveVoditel(Voditel item)
        {
            if (item.Id == 0)
            {
                db.Voditel.Add(item); //Добавлена вместо AddObject
                db.SaveChanges();
            }
            else
            {
                db.Voditel.Attach(db.Voditel.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //db.Voditels.ApplyCurrentValues(item);
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Voditels");
            return item.Id;
        }

        public bool DeleteVoditel(int id)
        {
            bool res = false;
            var item = db.Voditel.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Voditel.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Voditels");
            return res;
        }
        #endregion

        #region Группы_задач
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Группы_задач> GetГруппы_задач()
        {
            var res = new List<Группы_задач>();
            var key = "b_Группы_задач";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Группы_задач>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Группы_задач.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Группы_задач GetГруппы_задач(int ID)
        {
            var res = new Группы_задач();
            var key = "b_Группы_задач_Группы_задач" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Группы_задач)CacheManager.Cache[key];
            }
            else
            {
                res = db.Группы_задач.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveГруппы_задач(Группы_задач item)
        {
            if (item.Id == 0)
            {
                db.Группы_задач.Add(item); //Добавлена вместо AddObject
                db.SaveChanges();
            }
            else
            {
                db.Группы_задач.Attach(db.Группы_задач.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //db.Группы_задач.ApplyCurrentValues(item);
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Группы_задач");
            return item.Id;
        }

        public bool DeleteГруппы_задач(int id)
        {
            bool res = false;
            var item = db.Группы_задач.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Группы_задач.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Группы_задач");
            return res;
        }
        #endregion

        #region Тип_ТС
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Тип_ТС> GetТип_ТС()
        {
            var res = new List<Тип_ТС>();
            var key = "b_Тип_ТС";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Тип_ТС>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Тип_ТС.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Тип_ТС GetТип_ТС(int ID)
        {
            var res = new Тип_ТС();
            var key = "b_Тип_ТС_Тип_ТС" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Тип_ТС)CacheManager.Cache[key];
            }
            else
            {
                res = db.Тип_ТС.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveТип_ТС(Тип_ТС item)
        {
            item.Название_типа = item.Название_типа.Trim();
            if (item.Id == 0)
            {
                db.SaveChanges();
            }
            else
            {
                db.Тип_ТС.Attach(db.Тип_ТС.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Тип_ТС");
            return item.Id;
        }

        public bool DeleteТип_ТС(int id)
        {
            bool res = false;
            var item = db.Тип_ТС.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Тип_ТС.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Тип_ТС");
            return res;
        }
        #endregion

        #region Пункт_доставки
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Пункт_доставки> GetПункт_доставки()
        {
            var res = new List<Пункт_доставки>();
            var key = "b_Пункт_доставки";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Пункт_доставки>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Пункт_доставки.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Пункт_доставки GetПункт_доставки(int ID)
        {
            var res = new Пункт_доставки();
            var key = "b_Пункт_доставки_Пункт_доставки" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Пункт_доставки)CacheManager.Cache[key];
            }
            else
            {
                res = db.Пункт_доставки.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveПункт_доставки(Пункт_доставки item)
        {
            item.Название_пункта= item.Название_пункта.Trim();
            item.Адрес= item.Адрес.Trim();
            item.Регулярность= item.Регулярность.Trim();
            if (item.Id == 0)
            {
                db.SaveChanges();
            }
            else
            {
                db.Пункт_доставки.Attach(db.Пункт_доставки.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Пункт_доставки");
            return item.Id;
        }

        public bool DeleteПункт_доставки(int id)
        {
            bool res = false;
            var item = db.Пункт_доставки.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Пункт_доставки.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Пункт_доставки");
            return res;
        }
        #endregion

        #region Получатель
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Получатель> GetПолучатель()
        {
            var res = new List<Получатель>();
            var key = "b_Получатель";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Получатель>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Получатель.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Получатель GetПолучатель(int ID)
        {
            var res = new Получатель();
            var key = "b_Получатель_Получатель" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Получатель)CacheManager.Cache[key];
            }
            else
            {
                res = db.Получатель.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveПолучатель(Получатель item)
        {
            item.ФИО= item.ФИО.Trim();
            item.E_mail= item.E_mail.Trim();
            item.Телефон= item.Телефон.Trim();
            if (item.Id == 0)
            {
                db.SaveChanges();
            }
            else
            {
                db.Получатель.Attach(db.Получатель.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Получатель");
            return item.Id;
        }

        public bool DeleteПолучатель(int id)
        {
            bool res = false;
            var item = db.Получатель.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Получатель.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Получатель");
            return res;
        }
        #endregion

        #region Задача
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Задача> GetЗадача()
        {
            var res = new List<Задача>();
            var key = "b_Задача";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Задача>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Задача.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Задача GetЗадача(int ID)
        {
            var res = new Задача();
            var key = "b_Задача_Задача" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Задача)CacheManager.Cache[key];
            }
            else
            {
                res = db.Задача.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveЗадача(Задача item)
        {
            item.Название_задачи = item.Название_задачи.Trim();
            item.Примечание= item.Примечание.Trim();
            if (item.Id == 0)
            {
                db.SaveChanges();
            }
            else
            {
                db.Задача.Attach(db.Задача.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Задача");
            return item.Id;
        }

        public bool DeleteЗадача(int id)
        {
            bool res = false;
            var item = db.Задача.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Задача.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Задача");
            return res;
        }
        #endregion

        #region Автомобиль
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Автомобиль> GetАвтомобиль()
        {
            var res = new List<Автомобиль>();
            var key = "b_Автомобиль";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Автомобиль>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Автомобиль.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Автомобиль GetАвтомобиль(int ID)
        {
            var res = new Автомобиль();
            var key = "b_Автомобиль_Автомобиль" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Автомобиль)CacheManager.Cache[key];
            }
            else
            {
                res = db.Автомобиль.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveАвтомобиль(Автомобиль item)
        {
            item.Название_автомобиля = item.Название_автомобиля.Trim();
            item.Госномер= item.Госномер.Trim();
            item.Примечание = item.Примечание.Trim();
            if (item.Id == 0)
            {
                db.SaveChanges();
            }
            else
            {
                db.Автомобиль.Attach(db.Автомобиль.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Автомобиль");
            return item.Id;
        }

        public bool DeleteАвтомобиль(int id)
        {
            bool res = false;
            var item = db.Автомобиль.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Автомобиль.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Автомобиль");
            return res;
        }
        #endregion

        #region Маршрут
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Маршрут> GetМаршрут()
        {
            var res = new List<Маршрут>();
            var key = "b_Маршрут";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Маршрут>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Маршрут.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Маршрут GetМаршрут(int ID)
        {
            var res = new Маршрут();
            var key = "b_Маршрут_Маршрут" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Маршрут)CacheManager.Cache[key];
            }
            else
            {
                res = db.Маршрут.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveМаршрут(Маршрут item)
        {
            item.Название_маршрута = item.Название_маршрута.Trim();
            item.Примечание = item.Примечание.Trim();
            if (item.Id == 0)
            {
                db.SaveChanges();
            }
            else
            {
                db.Маршрут.Attach(db.Маршрут.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Маршрут");
            return item.Id;
        }

        public bool DeleteМаршрут(int id)
        {
            bool res = false;
            var item = db.Маршрут.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Маршрут.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Маршрут");
            return res;
        }
        #endregion

        #region Пункты_регулярного_маршрута
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public List<Пункты_регулярного_маршрута> GetПункты_регулярного_маршрута()
        {
            var res = new List<Пункты_регулярного_маршрута>();
            var key = "b_Пункты_регулярного_маршрута";

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (List<Пункты_регулярного_маршрута>)CacheManager.Cache[key];
            }
            else
            {
                res = db.Пункты_регулярного_маршрута.ToList();
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public Пункты_регулярного_маршрута GetПункты_регулярного_маршрута(int ID)
        {
            var res = new Пункты_регулярного_маршрута();
            var key = "b_Пункты_регулярного_маршрута_Пункты_регулярного_маршрута" + ID;

            if (CacheManager.EnableCaching && CacheManager.Cache[key] != null)
            {
                res = (Пункты_регулярного_маршрута)CacheManager.Cache[key];
            }
            else
            {
                res = db.Пункты_регулярного_маршрута.SingleOrDefault(x => x.Id == ID);
                CacheManager.CacheData(key, res);
            }

            return res;
        }

        public int SaveПункты_регулярного_маршрута(Пункты_регулярного_маршрута item)
        {
            item.Примечание = item.Примечание.Trim();
            if (item.Id == 0)
            {
                db.SaveChanges();
            }
            else
            {
                db.Пункты_регулярного_маршрута.Attach(db.Пункты_регулярного_маршрута.Single(x => x.Id == item.Id));
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            CacheManager.PurgeCacheItems("b_Пункты_регулярного_маршрута");
            return item.Id;
        }

        public bool DeleteПункты_регулярного_маршрута(int id)
        {
            bool res = false;
            var item = db.Пункты_регулярного_маршрута.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                db.Пункты_регулярного_маршрута.Remove(item);
                db.SaveChanges();
                res = true;
            }
            CacheManager.PurgeCacheItems("b_Пункты_регулярного_маршрута");
            return res;
        }
        #endregion




    }
}
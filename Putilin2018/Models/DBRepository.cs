﻿using System;
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
    }
}
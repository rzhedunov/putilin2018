using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Collections;

namespace Putilin2018.Models
{
    public abstract class CacheManager
    {
        public static bool EnableCaching { get { return true; } }
        public static int CacheDuration { get { return 600; } }

        public static System.Web.Caching.Cache Cache
        {
            get { return HttpContext.Current.Cache; }
        }

        public static void PurgeCacheItems(string prefix)
        {
            prefix = prefix.ToLower();
            List<string> itemsToRemove = new List<string>();

            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                if (enumerator.Key.ToString().ToLower().StartsWith(prefix))
                {
                    itemsToRemove.Add(enumerator.Key.ToString());
                }
            }

            foreach (string itemToRemove in itemsToRemove)
                Cache.Remove(itemToRemove);
        }

        public static void CacheData(string key, object data)
        {
            if (EnableCaching && data != null)
            {
                CacheManager.Cache.Insert(key, data, null,
                    DateTime.Now.AddMinutes(CacheDuration), TimeSpan.Zero);
            }
        }
    }
}
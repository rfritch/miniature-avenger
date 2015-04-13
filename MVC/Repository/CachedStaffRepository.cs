using MVC.Interfaces;
using MVC.Models;
using MVC.StaffServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Repository
{
    public class CachedStaffRepository : StaffRepository
    {
        private static readonly object CacheLockObject = new object();

        public override List<IStaff> GetStaff()
        {
            string cacheKey = "StaffMembers";
            var result = HttpRuntime.Cache[cacheKey] as List<IStaff>;
            if (result == null)
            {
                lock (CacheLockObject)
                {
                    result = HttpRuntime.Cache[cacheKey] as List<IStaff>;
                    if (result == null)
                    {
                        result = base.GetStaff();
                        HttpRuntime.Cache.Insert(cacheKey, result, null,
                            DateTime.Now.AddSeconds(60), TimeSpan.Zero);
                    }
                }
            }
            return result;
        }
    }
}

using MVC.AppointmentServiceReference;
using MVC.Interfaces;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Repository
{
    public class CachedAppointmentRepository : AppointmentRepository
    {
        private static readonly object CacheLockObject = new object();

        public override List<IAppointment> GetStaffAppointments(IStaff staff, DateTime appointmentDate)
        {
            string cacheKey = "StaffAppointments-" + staff.ID.ToString() + appointmentDate.ToShortTimeString();
            var result = HttpRuntime.Cache[cacheKey] as List<IAppointment>;
            if (result == null)
            {
                lock (CacheLockObject)
                {
                    result = HttpRuntime.Cache[cacheKey] as List<IAppointment>;
                    if (result == null)
                    {
                        result = base.GetStaffAppointments(staff, appointmentDate);
                        HttpRuntime.Cache.Insert(cacheKey, result, null,
                            DateTime.Now.AddSeconds(60), TimeSpan.Zero);
                    }
                }
            }
            return result;
        }
    }
}
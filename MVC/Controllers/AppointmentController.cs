using MVC.Interfaces;
using MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appointment/
        public ActionResult Get(IStaff staffId, DateTime date)
        {
            //TODO make this a cache 
            IAppointmentRepository appointmentRepo = new AppointmentRepository();
            IOrderedEnumerable<IAppointment> appointments = appointmentRepo.GetStaffAppointments(staffId, date).OrderByDescending(a => a.StartDateTime);

            return View(appointments.ToList());
        }


    }
}

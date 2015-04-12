using MVC.Interfaces;
using MVC.Models;
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

        // GET : by ID and Date 
        public ActionResult Get(long staffId, DateTime date)
        {
            IStaffRepository staffRepo = new StaffRepository();
            IEnumerable<IStaff> staffMember = staffRepo.GetStaff().Where((m => m.ID == staffId));
 
            IAppointmentRepository appointmentRepo = new AppointmentRepository();
            IOrderedEnumerable<IAppointment> appointments = appointmentRepo.GetStaffAppointments( staffMember.First(), date).OrderByDescending(a => a.StartDateTime);

            return View(appointments.ToList());
        }
    }
}

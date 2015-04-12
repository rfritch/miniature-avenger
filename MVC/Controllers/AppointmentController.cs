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
        //GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

        //POST : by ID and Date 
        [HttpPost]
        public ActionResult Get(StaffViewModel staff, DateTime date) 
        {
            long staffId = staff.SelectedStaffId;
            //DateTime date = new DateTime(2014, 1, 3);

            IStaffRepository staffRepo = new StaffRepository();
            IEnumerable<IStaff> staffMember = staffRepo.GetStaff().Where((m => m.ID == staffId));
 
            IAppointmentRepository appointmentRepo = new AppointmentRepository();
            IOrderedEnumerable<IAppointment> appointments = appointmentRepo.GetStaffAppointments( staffMember.First(),  date).OrderByDescending(a => a.StartDateTime);

            return View(appointments.ToList());
        }
    }
}

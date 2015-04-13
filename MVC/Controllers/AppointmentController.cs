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
        private readonly IStaffRepository _staffRepo;
        private readonly IAppointmentRepository _appointmentRepo;

        public AppointmentController(IAppointmentRepository appointmentRepo, IStaffRepository staffRepo)
        {
            _appointmentRepo = appointmentRepo;
            _staffRepo = staffRepo;
        }
        
        //POST:   
        [HttpPost]
        public ActionResult PartialAppointmentView(StaffViewModel staff, DateTime date)
        {
            try
            {
                IStaff aStaff = _staffRepo.GetStaff().Where(m => m.ID == staff.SelectedStaffId).First();
                IOrderedEnumerable<IAppointment> appointments = _appointmentRepo.GetStaffAppointments(aStaff, date).OrderByDescending(a => a.StartDateTime);
                return PartialView(appointments);
            }
            catch (Exception e)
            {
                List<IAppointment> appointments = new List<IAppointment>();
                return PartialView(appointments);
            }

        }

    }
}

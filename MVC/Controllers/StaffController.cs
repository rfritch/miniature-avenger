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
    public class StaffController : Controller
    {
        private readonly IStaffRepository _staffRepo;

        public StaffController (IStaffRepository staffRepo)
        {
            _staffRepo = staffRepo;
        }
        
        // GET: Staff
        public ActionResult Index()
        {
            //Convert to the view Model
            StaffViewModel viewModel = new StaffViewModel()
            {                
                StaffMemberList = _staffRepo.GetStaff().OrderBy(s => s.LastName)
            };

            //Combine model with view and return
            return View(viewModel);
        }
    }
}

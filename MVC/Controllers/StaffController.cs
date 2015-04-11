using MVC.Interfaces;
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
        // GET: Staff
        public ActionResult Index()
        {
            //Get the model
            IStaffRepository staffRepo = new StaffRepository();
            IOrderedEnumerable<IStaff> staffMembers = staffRepo.GetStaff().OrderBy(s => s.LastName);

            //Combine model with view and return
            return View(staffMembers.ToList());
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Controllers;
using MVC.Models;
using MVC.Interfaces;
using MVC.Repository;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {

        private IStaff _staff;

        [TestInitialize]
        public void Setup()
        {
            var repo = new StaffRepository();

            //Grab the first staff member form the list
            _staff = repo.GetStaff().First();
        }

        [TestMethod]
        public void TestPartialAppointmentView()
        {
            var controller = new AppointmentController(new AppointmentRepository(), new StaffRepository());
            StaffViewModel s = new StaffViewModel();
            s.SelectedStaffId = _staff.ID;

            DateTime appointmentDate = DateTime.ParseExact("2014-01-03", "yyyy-MM-dd", null);      
            var result = controller.PartialAppointmentView(s, appointmentDate) as PartialViewResult;
            //SHould probably build a more robust test
            Assert.IsNotNull(result);

        }
    }
}

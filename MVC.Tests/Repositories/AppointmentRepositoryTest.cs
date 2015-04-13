using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Interfaces;
using MVC.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Tests.Controllers
{
    [TestClass]
    public class AppointmentRepositoryTest
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
        public void GetAppointmentsHasData()
        {
            var repo = new AppointmentRepository();

            DateTime appointmentDate = DateTime.ParseExact("2014-01-03", "yyyy-MM-dd", null);

            List<IAppointment> appointments = repo.GetStaffAppointments(_staff, appointmentDate);

            Assert.IsNotNull(appointments);
            Assert.IsTrue(appointments.Any());
            Assert.IsNotNull(appointments.First());
        }
    }
}


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC.Interfaces;
using MVC.Repository;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Tests.Controllers
{
    [TestClass]
    public class StaffRepositoryTest
    {
        [TestMethod]
        public void GetStaffMembersHasData()
        {
            var repo = new StaffRepository();

            List<IStaff> staffMembers = repo.GetStaff();

            Assert.IsNotNull(staffMembers);
            Assert.IsTrue(staffMembers.Any());
            Assert.IsNotNull(staffMembers.First());

            // Check data items needed for GetStaffAppointments
            Assert.IsNotNull(staffMembers.First().ID);
            Assert.IsNotNull(staffMembers.First().FirstName);
            Assert.IsNotNull(staffMembers.First().LastName);
        }
    }
}


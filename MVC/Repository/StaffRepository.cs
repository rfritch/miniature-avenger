using MVC.Interfaces;
using MVC.Models;
using MVC.StaffServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//TODO: refine this
namespace MVC.Repository
{
    public class StaffRepository : IStaffRepository
    {
        public List<IStaff> GetStaff()
        {
            var request = new GetStaffRequest
            {
                SourceCredentials = new SourceCredentials
                {
                    SourceName = "MBO.Russel.Fritch",
                    Password = "ycYj3mAcs0EzIlE8rTS+qW4BiQI=",
                    SiteIDs = new ArrayOfInt {-31100}
                },
            };

            var proxy = new StaffServiceSoapClient();
            GetStaffResult response = proxy.GetStaff(request);

            return response.StaffMembers.Where((member) => member.ID > 0).Select( (member) => new StaffModel
            {
                ID = member.ID,
                FirstName = member.FirstName,
                LastName = member.LastName,
                
            }).Cast<IStaff>().ToList();
        }
    }
}

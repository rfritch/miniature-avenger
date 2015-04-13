using MVC.AppointmentServiceReference;
using MVC.Interfaces;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public virtual List<IAppointment> GetStaffAppointments(IStaff staff, DateTime appointmentDate)
        {
            // Appointments might span midnight
            DateTime endDate = appointmentDate.AddDays(1);    

            var request = new GetStaffAppointmentsRequest
            {
                SourceCredentials = new SourceCredentials
                {
                    SourceName = "MBO.Russel.Fritch",
                    Password = "ycYj3mAcs0EzIlE8rTS+qW4BiQI=",
                    SiteIDs = new ArrayOfInt { -31100 }
                },

                StaffCredentials = new StaffCredentials
                {
                    Username = string.Format("{0}.{1}", staff.FirstName, staff.LastName),
                    Password = string.Format("{0}{1}{2}", staff.FirstName.ToLower()[0], staff.LastName.ToLower()[0], staff.ID),
                    SiteIDs = new ArrayOfInt { -31100 }
                },
                StartDate = appointmentDate,
                EndDate = endDate,  
            };
            var proxy = new AppointmentServiceSoapClient();
            GetStaffAppointmentsResult response = proxy.GetStaffAppointments(request);
            
            return response.Appointments.Select(appointment => new AppointmentModel
            {
                ID = appointment.ID,
                StartDateTime = appointment.StartDateTime,
                EndDateTime = appointment.EndDateTime,
                ClientName = string.Format("{0} {1}", appointment.Client.FirstName, appointment.Client.LastName),
                SessionType = appointment.SessionType.Name
                
            }).Cast<IAppointment>().ToList();
        }
    }
}
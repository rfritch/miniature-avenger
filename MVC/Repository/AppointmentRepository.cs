﻿using MVC.AppointmentServiceReference;
using MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//TODO: Refine
namespace MVC.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public List<IAppointment> GetStaffAppointments(IStaff staff, DateTime appointmentDate)
        {
            var request = new GetStaffAppointmentsRequest
            {
                // Set Source Credentials
                SourceCredentials = new SourceCredentials
                {
                    SourceName = "MBO.Russel.Fritch",
                    Password = "ycYj3mAcs0EzIlE8rTS+qW4BiQI=",
                    SiteIDs = new ArrayOfInt { -31100 }
                },

                StaffCredentials = new StaffCredentials
                {
                    Username = string.Format("{0}.{1}", staff.FirstName, staff.LastName),
                    Password = string.Format("{0}{1}{2}", staff.FirstName[0], staff.LastName[0], staff.ID),
                    SiteIDs = new ArrayOfInt { -31100 }
                },

                StartDate = appointmentDate,
                EndDate = appointmentDate
            };

            var proxy = new AppointmentServiceSoapClient();
            GetStaffAppointmentsResult response = proxy.GetStaffAppointments(request);

            return response.Appointments.Select(appointment => new Appointment
            {
                ID = appointment.ID,
                StartDateTime = appointment.StartDateTime,
                EndDateTime = appointment.EndDateTime,
            }).Cast<IAppointment>().ToList();
        }

    }
}
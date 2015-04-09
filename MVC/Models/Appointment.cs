using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MVC.Models
{
    public class Appointment
    {
        //    <GenderPreference>string</GenderPreference>
        //    <Duration>int</Duration>
        //    <Action>None or Added or Updated or Failed or Removed</Action>



        //    <ID>long</ID>
        public int ID { get; set; }

        //    <Status>Booked or Completed or Confirmed or Arrived or NoShow or Cancelled</Status>

        //    <StartDateTime>dateTime</StartDateTime>
        [DataType(DataType.DateTime)]
        public DateTime StartDateTime { get; set; }

        //    <EndDateTime>dateTime</EndDateTime>
        [DataType(DataType.DateTime)]
        public DateTime EndDateTime { get; set; }

        //    <Notes>string</Notes>
        //    <StaffRequested>boolean</StaffRequested>
        //    <Program xsi:nil="true" />
        //    <SessionType xsi:nil="true" />
        //    <Location xsi:nil="true" />
        //    <Staff xsi:nil="true" />
        //    <Client xsi:nil="true" />
        //    <FirstAppointment>boolean</FirstAppointment>
        //    <ClientService xsi:nil="true" />
        //    <Resources xsi:nil="true" />
    }
}

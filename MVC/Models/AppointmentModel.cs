using MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MVC.Models
{
    public class AppointmentModel : IAppointment
    {
        public long? ID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? StartDateTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EndDateTime { get; set; }
    }
}

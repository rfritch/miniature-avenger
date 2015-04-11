using MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class StaffModel : IStaff
    {
        public List<IAppointment> Appointments { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        public long? ID { get; set; }
        
        public String FirstName { get; set; }
        
        public String LastName { get; set; }
        
        [DataType(DataType.Url)]
        public String ImageURL { get; set; }
    }
}
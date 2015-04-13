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
        public long? ID { get; set; }
        
        public String FirstName { get; set; }
        
        public String LastName { get; set; }

        public String Name { get; set; }
              
    }
}
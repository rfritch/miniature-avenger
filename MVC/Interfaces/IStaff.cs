using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public interface IStaff
    {
        long? ID { get; set; }
        
        String FirstName { get; set; }
        
        String LastName { get; set; }
    }
}

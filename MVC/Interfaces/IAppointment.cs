using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public interface IAppointment
    {
        long? ID { get; set; }
        DateTime? StartDateTime { get; set; }
        DateTime? EndDateTime { get; set; }
        string SessionType { get; set; }
        string ClientName { get; set; }
    }
}

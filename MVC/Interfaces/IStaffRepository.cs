using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public interface IStaffRepository
    {
        List<IStaff> GetStaff();
    }
}

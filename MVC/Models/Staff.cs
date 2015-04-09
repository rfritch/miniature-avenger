using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Staff
    {
        public Staff(int Id)
        {
            var mbSoapService = new mbSoapService(new Uri("YourURL"));
            Name = mbSoapService.Persons.Where(x => x.Id == Id).Select(x => x.Name);
        }

        // <Appointments xsi:nil="true" />
        public List<Appointment> Appointments { get; set; }

        // <Unavailabilities xsi:nil="true" />
        public List<Appointment> Unavailabilities { get; set; }

        //<Email>string</Email>
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        //<MobilePhone>string</MobilePhone>
        //<HomePhone>string</HomePhone>
        //<WorkPhone>string</WorkPhone>
        //<Address>string</Address>
        //<Address2>string</Address2>
        //<City>string</City>
        //<State>string</State>
        //<Country>string</Country>
        //<PostalCode>string</PostalCode>
        //<ForeignZip>string</ForeignZip>
        //<SortOrder>int</SortOrder>
        //<LoginLocations xsi:nil="true" />
        //<MultiLocation>boolean</MultiLocation>
        //<Action>None or Added or Updated or Failed or Removed</Action>

        //<ID>long</ID>
        public int ID { get; set; }

        //<Name>string</Name>
        public String Name { get; set; }

        //<FirstName>string</FirstName>
        public String FirstName { get; set; }

        //<LastName>string</LastName>
        public String LastName { get; set; }

        //<ImageURL>string</ImageURL>
        [DataType(DataType.Url)]
        public String ImageURL { get; set; }

        //<Bio>string</Bio>
        //<isMale>boolean</isMale>
    }
}
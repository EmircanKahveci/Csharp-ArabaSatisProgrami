using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerNo {get; set;}
        public string TcNo { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DateofBirth { get; set; }
        public string Profession { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string LicenseType { get; set; }
        
        

    }
}

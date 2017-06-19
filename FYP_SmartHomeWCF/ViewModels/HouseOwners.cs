using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class HouseOwners
    {
        public House house { get; set; }
        public IEnumerable<User> users { get; set; }
    }
}
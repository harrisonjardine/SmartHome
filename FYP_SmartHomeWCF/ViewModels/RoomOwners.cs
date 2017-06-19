using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class RoomOwners
    {
        public Room room { get; }
        public IEnumerable<User> users { get; set; }
    }
}
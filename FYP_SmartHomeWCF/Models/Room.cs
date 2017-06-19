using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class Room
    {
        public Guid RoomGuid { get; set; }
        public Guid HouseGuid { get; set; }
        public String RoomName { get; set; }
    }
}
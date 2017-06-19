using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class HouseRooms
    {
        public House house { get; set; }
        public IList<Room> rooms { get; set; }
    }
}
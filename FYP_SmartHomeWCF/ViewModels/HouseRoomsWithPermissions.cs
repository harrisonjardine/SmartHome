using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class HouseRoomsWithPermission
    {
        public Guid house { get; set; }
        public IList<KeyValuePair<Boolean,Room>> roomsPermission { get; set; }
    }
}
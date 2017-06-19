using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class HouseOwner
    {
        public House house { get; set; }
        public Guid ownerGuid { get; set; }
    }
}
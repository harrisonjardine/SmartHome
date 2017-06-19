using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class RoomOwner
    {
        public Guid room { get; set; }
        public Guid user { get; set; }
        public string desc { get; set; }
    }
}
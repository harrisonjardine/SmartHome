using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class RoomObjects
    {
        public Guid roomGuid { get; set; }
        public IEnumerable<Object> objects { get; set; }
    }
}
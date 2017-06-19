using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class Object
    {
        public Guid ObjectGuid { get; set; }
        public Guid RoomGuid { get; set; }
        public Guid HouseGuid { get; set; }
        public Guid ObjectTypeGuid { get; set; }
        public String ObjectType { get; set; }
        public String ObjectDescription { get; set; }
        public String ObjectState { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class UserHomes
    {
        public Guid userGuid { get; set; }
        public IList<House> homes { get; set; }
    }
}
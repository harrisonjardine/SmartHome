using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_SmartHomeWCF.Models
{
    public class HouseObjects
    {
        public Guid houseGUID { get; set; }
        public IList<Object> objects { get; set; }
    }
}
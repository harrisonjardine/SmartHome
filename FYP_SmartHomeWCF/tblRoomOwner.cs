//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FYP_SmartHomeWCF
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblRoomOwner
    {
        public long ID { get; set; }
        public Nullable<System.Guid> RoomGUID { get; set; }
        public Nullable<System.Guid> UserGUID { get; set; }
    
        public virtual tblRoom tblRoom { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}

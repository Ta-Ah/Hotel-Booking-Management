//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PAYMENT
    {
        public int PATMENT_ID { get; set; }
        public int Booking_id { get; set; }
        public Nullable<System.DateTime> PAYMENT_DATE { get; set; }
        public int TOTAL_AMMOUNT { get; set; }
    
        public virtual Booking Booking { get; set; }
    }
}

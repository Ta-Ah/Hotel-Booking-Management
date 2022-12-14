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
    
    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            this.PAYMENTs = new HashSet<PAYMENT>();
        }
    
        public int Booking_id { get; set; }
        public int Guest_id { get; set; }
        public Nullable<System.DateTime> Booking_date { get; set; }
        public System.DateTime Check_in { get; set; }
        public System.DateTime Check_out { get; set; }
        public int Guest_num { get; set; }
        public string Room_type { get; set; }
        public Nullable<int> Total_Room { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PAYMENT> PAYMENTs { get; set; }
        public virtual GUEST_TABLE GUEST_TABLE { get; set; }
        public virtual room_tab room_tab { get; set; }
    }
}

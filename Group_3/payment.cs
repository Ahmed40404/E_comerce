//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Group_3
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment
    {
        public int payment_id { get; set; }
        public int order_id { get; set; }
        public decimal amount { get; set; }
        public System.DateTime payment_Date { get; set; }
        public string payment_Method { get; set; }
    
        public virtual order order { get; set; }
    }
}

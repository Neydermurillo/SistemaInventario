//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Taxes
    {
        public int IdTaxes { get; set; }
        public string Taxes1 { get; set; }
        public Nullable<decimal> Percents { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> SaleId { get; set; }
        public Nullable<int> Shopping { get; set; }
        public bool Status { get; set; }
    
        public virtual Sales Sales { get; set; }
        public virtual Shopping Shopping1 { get; set; }
    }
}
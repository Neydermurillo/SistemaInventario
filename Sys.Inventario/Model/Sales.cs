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
    
    public partial class Sales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sales()
        {
            this.Taxes = new HashSet<Taxes>();
        }
    
        public int IdSale { get; set; }
        public string Sale { get; set; }
        public int UsersId { get; set; }
        public int ProductId { get; set; }
        public Nullable<decimal> UnitCost { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public Nullable<decimal> NetCost { get; set; }
        public Nullable<decimal> GreatCost { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Quantity { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Taxes> Taxes { get; set; }
    }
}

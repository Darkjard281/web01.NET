//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIWEB01
{
    using System;
    using System.Collections.Generic;
    
    public partial class TMaestro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TMaestro()
        {
            this.TDetalle = new HashSet<TDetalle>();
        }
    
        public long ConMaestro { get; set; }
        public long ConUsuario { get; set; }
        public decimal TotalFactura { get; set; }
        public System.DateTime FechaCompra { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TDetalle> TDetalle { get; set; }
        public virtual TUsuarios TUsuarios { get; set; }
    }
}
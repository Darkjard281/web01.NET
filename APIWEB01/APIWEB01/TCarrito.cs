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
    
    public partial class TCarrito
    {
        public long ConCarrito { get; set; }
        public long ConUsuario { get; set; }
        public long ConProducto { get; set; }
        public int Cantidad { get; set; }
        public System.DateTime Fecha { get; set; }
    
        public virtual TProducto TProducto { get; set; }
        public virtual TUsuarios TUsuarios { get; set; }
    }
}
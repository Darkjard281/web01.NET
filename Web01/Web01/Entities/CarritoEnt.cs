using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web01.Entities
{
    public class CarritoEnt
    {
        public long ConCarrito { get; set; }
        public long ConUsuario { get; set; }
        public long ConProducto { get; set; }
        public int Cantidad { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public string Nombre { get; set; }
    }
}
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
    }
}
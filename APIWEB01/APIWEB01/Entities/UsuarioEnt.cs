using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWEB01.Entities
{
    public class UsuarioEnt
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

    }
}
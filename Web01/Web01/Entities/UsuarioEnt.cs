using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web01.Entities
{
    public class UsuarioEnt
    {
        //Aqui se guardan todos los atributos de este Entidad
        public long ConUsuario { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

    }
}
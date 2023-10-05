using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWEB01.Entities;//Agregamos la referencia de la carpeta

namespace APIWEB01.Controllers
{
    public class LoginController : ApiController
    {

        [HttpPost]// Se recibe el objeto ya que si pasamos por parametro mediante el metodo get queda expuesta la informacion
        [Route("Login")]//Parametro obligatorio para darle un alias al metodo
        public void Login(UsuarioEnt entidad) //objeto / alias
        {

        }

        [HttpPost]
        [Route("RegistrarCuenta")]
        public void RegistrarCuenta(UsuarioEnt entidad)
        {

        }

        public void RecuperarCuenta(UsuarioEnt entidad)
        {

        }

    }
}

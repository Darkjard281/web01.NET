using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Web.Http;

namespace APIWEB01.Controllers
{
    public class CarritoController : ApiController
    {

        [HttpPost]
        [Route("RegistrarCarrito")]
        public string RegistrarCarrito(TCarrito tcarrito)
        {
            using (var context = new DBMN())
            {

                context.TCarrito.Add(tcarrito);
                context.SaveChanges();
                return "OK";
            }
        }

        [HttpGet]
        [Route("ConsultarCarrito")]
        public List<TCarrito> ConsultarCarrito(long q) {

            using (var context = new DBMN())
            {
                return context.TCarrito.Where(x => x.ConUsuario == q).ToList();

            }
        }
    }
}

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

                var datos = (from x in context.TCarrito
                             where x.ConUsuario == tcarrito.ConUsuario 
                             && x.ConProducto == tcarrito.ConProducto
                             select x ).FirstOrDefault();

                if (datos == null)
                {
                    context.TCarrito.Add(tcarrito);
                    context.SaveChanges();

                }
                else {
                    datos.Cantidad = tcarrito.Cantidad;
                    context.SaveChanges();
                }


                return "OK";
            }
        }

        [HttpGet]
        [Route("ConsultarCarrito")]
        public object ConsultarCarrito() {

            using (var context = new DBMN())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return (from c in context.TCarrito
                        join p in context.TProducto on c.ConProducto equals p.ConProducto
                        select new {
                            c.ConProducto,
                            c.ConCarrito,
                            c.ConUsuario,
                            c.Cantidad,
                            c.Fecha,
                            p.Precio,
                            p.Nombre,
                            Subtotal = p.Precio * c.Cantidad, //Creados
                            Impuesto = (p.Precio * c.Cantidad) * 0.13M, //Creados -- Constantes decimales se le agrega una M
                            Total = (p.Precio * c.Cantidad) + (p.Precio * c.Cantidad) * 0.13M
                        }).ToList();

            }
        }

        [HttpPost]
        [Route("PagarCarrito")]
        public int PagarCarrito(TCarrito tCarrito)
        {
            using (var context = new DBMN())
            {
                return context.PagarCarrito_SP(tCarrito.ConUsuario);
                
            }
        }

    }

}

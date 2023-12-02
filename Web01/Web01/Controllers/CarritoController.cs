using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web01.Entities;
using Web01.Models;

namespace Web01.Controllers
{
    public class CarritoController : Controller
    {


        CarritoModel carritoModelo = new CarritoModel();

        [HttpPost]
        public ActionResult RegistrarCarrito(long conProducto, int cantidad)
        {
           CarritoEnt entidad = new CarritoEnt();
            entidad.ConUsuario = long.Parse(Session["ConUsuario"].ToString());
            entidad.ConProducto = conProducto; 
            entidad.Cantidad = cantidad;
            entidad.Fecha = DateTime.Now;

            carritoModelo.RegistrarCarrito(entidad);

            var datos = carritoModelo.ConsultarCarrito().Where(x => x.ConUsuario == entidad.ConUsuario);
            Session["Cantidad"] = datos.Sum(x=>x.Cantidad);
            Session["Subtotal"] = datos.Sum(x => x.Precio);


            return Json("OK", JsonRequestBehavior.AllowGet); //Cuando se responde a un AJAX tiene que devolvers en un JSON

        }

        [HttpGet]
        public ActionResult ConsultarCarrito()
        {
            var datos = carritoModelo.ConsultarCarrito().Where(x => x.ConUsuario == long.Parse(Session["ConUsuario"].ToString()));
            Session["Total"] =  datos.Sum(x => x.Total);
            return View(datos);
        }

        [HttpPost]
        public ActionResult PagarCarrito()
        {
            CarritoEnt carritoEnt = new CarritoEnt();
            carritoEnt.ConUsuario = long.Parse(Session["ConUsuario"].ToString());


            if (carritoModelo.PagarCarrito(carritoEnt) > 0)
            {
                var datos = carritoModelo.ConsultarCarrito().Where(x => x.ConUsuario == carritoEnt.ConUsuario);
                Session["Cantidad"] = datos.Sum(x => x.Cantidad);
                Session["Subtotal"] = datos.Sum(x => x.Precio);

                return RedirectToAction("Index", "Login");
            }
            else {

                ViewBag.Mensaje = "No se pudo realizar su compra. Verifique las unidades disponibles de su carrito";
                return View();
            }

            
        }


    }
}
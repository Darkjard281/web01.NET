using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web01.Models;

namespace Web01.Controllers
{
    public class CarritoController : Controller
    {

        CarritoModel carritoModel = new CarritoModel();

        [HttpPost]
        public ActionResult RegistrarCarrito()
        {
           return View();
        }


    }
}
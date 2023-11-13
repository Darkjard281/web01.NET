using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web01.Entities;
using Web01.Models;

namespace Web01.Controllers
{
    public class ProductoController : Controller
    {

        ProductoModel productModel = new ProductoModel();

        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            var datos = productModel.ConsultarProductos();
            return View(datos);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web01.Models;

namespace Web01.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModelo model = new UsuarioModelo();

        [HttpGet]
        public ActionResult PerfilUsuario()
        {
            var provincias = new List<SelectListItem>();
            ViewBag.provincias = model.ConsultarProvincias();
            return View();
        }
    }
}
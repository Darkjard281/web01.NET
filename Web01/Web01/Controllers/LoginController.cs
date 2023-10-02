using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web01.Entities;
using Web01.Models;

namespace Web01.Controllers
{
    public class LoginController : Controller
    {

        UsuarioModelo usuarioModelo = new UsuarioModelo();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioEnt entidad)
        {
            usuarioModelo.Login(entidad);
            return View();
        }

        [HttpGet]
        public ActionResult RegistrarCuenta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarCuenta(UsuarioEnt entidad)
        {
            usuarioModelo.RegistrarCuenta(entidad);
            return View();
        }

        [HttpGet]
        public ActionResult RecuperarCuenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarCuenta(UsuarioEnt entidad)
        {
            usuarioModelo.RecuperarCuenta(entidad);
            return View();
        }

    }
}
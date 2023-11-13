using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web01.Entities;
using Web01.Models;

namespace Web01.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModelo usuarioModel = new UsuarioModelo();


        [HttpGet]//Se puede utilizar con o sin pantalla en comparacion de un POST que esta ligado a una
        public ActionResult ConsultarUsuarios()
        {
            long ConUsuario = long.Parse(Session["ConUsuario"].ToString());
            var datos = usuarioModel.ConsultarUsuarios().Where(x=> x.ConUsuario !=ConUsuario).ToList();
            return View(datos);
        }

        [HttpGet]
        public ActionResult PerfilUsuario()
        {
            long ConUsuario = long.Parse(Session["ConUsuario"].ToString());
            var datos = usuarioModel.ConsultaUsuario(ConUsuario);//Ver con el profe
            ViewBag.provincias = usuarioModel.ConsultarProvincias();//Ver con el profe
            return View(datos);
        }

        [HttpPost]
        public ActionResult PerfilUsuario(UsuarioEnt entUsuario)
        {
            var resp = usuarioModel.ActaulizarCuenta(entUsuario);
             
            if (resp == "OK") {
                Session["Nombre"] = entUsuario.Nombre;
                return RedirectToAction("Index", "Login");
            }
            else{
                ViewBag.mensaje = "No se puede actualizar la informacion de su perfil";
                ViewBag.provincias = usuarioModel.ConsultarProvincias();
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult ActualizarEstadoUsuario(long q) {//el alias tiene que llamarse igual al de la vista

            var entidad = new UsuarioEnt();
            entidad.ConUsuario = q;
            var resp = usuarioModel.ActualizarEstadoUsuario(entidad);

            if (resp == "OK")
            {
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            }
            else {

                ViewBag.Mensaje = "No se pudo actualizar el estado del Usuario";
                return View();
            }

        }


        [HttpGet]
        public ActionResult ActualizarUsuario(long q)
        {
            ViewBag.Provincias = usuarioModel.ConsultarProvincias();
            var datos = usuarioModel.ConsultaUsuario(q);
            return View(datos);

        }

        [HttpPost]
        public ActionResult ActualizarUsuario(UsuarioEnt entUsuario)
        {
            var resp = usuarioModel.ActaulizarCuenta(entUsuario);

            if (resp == "OK")
            {
                
                return RedirectToAction("ConsultarUsuarios", "Usuario");
            }
            else
            {
                ViewBag.mensaje = "No se puede actualizar la informacion de este perfil";
                ViewBag.provincias = usuarioModel.ConsultarProvincias();
                return View();
            }

        }

    }
}
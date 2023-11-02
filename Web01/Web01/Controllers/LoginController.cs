﻿using System;
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

        [HttpGet]//Obtener la vista
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]//Obtener lo que se recibe por medio de la vista -- Ejecutar Acciones Solo existe en web estas 2(GET Y POST)
        public ActionResult Login(UsuarioEnt entidad)
        {
            var resp = usuarioModelo.Login(entidad);
            if (resp != null)
            {
                Session["NombreUsuario"] = resp.Nombre;//Variable de sesion (Cuando queramos y donde queramos) --> del servidor y Cookies(Del navegador) 
                return RedirectToAction("Index", "Login");//vista + controlador
            }
            else {
                ViewBag.MensajeUsuario = "Credenciales invalidos"; 
                return View();
            }
            
        }

        [HttpGet]
        public ActionResult RegistrarCuenta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrarCuenta(UsuarioEnt entidad)
        {

            var resp = usuarioModelo.RegistrarCuenta(entidad);
            if (resp == "OK") {
                return RedirectToAction("Index", "Login");
            } else {
                ViewBag.MensajeUsuario = "No se ha registrado su informacion";//Variable dinamica
                return View();
            }
            
            
        }

        [HttpGet]
        public ActionResult RecuperarCuenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarCuenta(UsuarioEnt entidad)
        {
            var resp = usuarioModelo.RecuperarCuenta(entidad);
            if (resp == "OK")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.MensajeUsuario = "No se ha enviado el correo con su contraseña";
                return View();
            }
        }

        [HttpGet]//No se pasa nada por parametros
        public ActionResult CerrarSesion(){
            Session.Clear();// Se vacia variable de sesion
            return RedirectToAction("Login", "Login");

        }

    }
}
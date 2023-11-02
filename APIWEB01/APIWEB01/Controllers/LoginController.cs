using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; // Tecnología desarrollada por Microsoft que permite realizar consultas y manipulación de datos directamente en lenguajes de programación como C# (C Sharp) y Visual Basic . NET
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using APIWEB01.Entities;//Agregamos la referencia de la carpeta

namespace APIWEB01.Controllers
{
    public class LoginController : ApiController
    {

        Utilitario util = new Utilitario();

        [HttpPost]// Se recibe el objeto ya que s   i pasamos por parametro mediante el metodo get queda expuesta la informacion
        [Route("Login")]//Parametro obligatorio para darle un alias al metodo
        public IniciarSesion_SP_Result Login(UsuarioEnt entidad) //objeto / alias
        {       //TUsuarios

            try {
                using (var context = new DBMN()) {
                    /*
                    var datos = (from x in context.TUsuarios //Sytaxis con Linq from / where /select -->Linq
                                 where x.Correo == entidad.Correo
                                 && x.Contrasena == entidad.Contrasena
                                 && x.Estado == true
                                 select x).FirstOrDefault();

                    return datos;

                    */

                    return context.IniciarSesion_SP(entidad.Correo,entidad.Contrasena).FirstOrDefault();

                    
                                 
                }
            }catch (Exception)
            {
                return null;
            }

        }



        [HttpPost] //
        [Route("RegistrarCuenta")]
        public string RegistrarCuenta(UsuarioEnt entidad) //Se recibe un objeto de tipo Usuario
        {

            try {
                using (var context = new DBMN()){ //Delimitador de acceso para la base de datos 

                    /* Sin SP (Procedimiento Almacenamiento)
                    TUsuarios user = new TUsuarios(); //Instancia de la tabla usuario
                    user.Identificacion = entidad.Identificacion; //Se almacena en user los atributos que se reciben de la entidad
                    user.Nombre = entidad.Nombre;
                    user.Correo = entidad.Correo;
                    user.Contrasena = entidad.Contrasena;
                    user.Direccion = entidad.Direccion;
                    user.Estado = entidad.Estado;

                    context.TUsuarios.Add(user);//Agregar el usuario a la conexion y tabla
                    context.SaveChanges();//Confirmar el usuario y guardarlo
                    */

                    context.REGISTRARCUENTA_SP(entidad.Identificacion,entidad.Nombre,entidad.Correo,entidad.Contrasena); //Con SP(Procedimiento Almacenamiento)
                    return "OK";
                }                                                     

            } catch (Exception e) {
                return e.Message;
            }

        }

        [HttpPost]
        [Route("RecuperarCuenta")]
        public string RecuperarCuenta(UsuarioEnt entidad)
        {

            
            try {
                using (var context = new DBMN())
                {
                    var datos = (from x in context.TUsuarios
                                 where x.Identificacion == entidad.Identificacion
                                 select x).FirstOrDefault();

                    if (datos != null)
                    {
                        string urlHtml = AppDomain.CurrentDomain.BaseDirectory + "Templates\\Email.html";
                        string html = File.ReadAllText(urlHtml);
                        html = html.Replace("@@Nombre", datos.Nombre);
                        html = html.Replace("@@Contrasena", datos.Contrasena);
                        util.EnvioCorreos(datos.Correo, "Recuperar Contraseña", html);
                    }
                        
                }
                return "OK";
            }
            catch(Exception e)
            {
                return e.Message;
            }
             

        }


        [HttpGet]
        [Route("ConsultarProvincias")]
        public List<System.Web.Mvc.SelectListItem> ConsultarProvincias() {
            
                using (var context = new DBMN())
                {
                    var datos =(from x in context.TProvincia
                            select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos) {

                    respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.ConProvincia.ToString(), Text = item.Descripcion });
                    
                }

                    return respuesta;


                }
            }
            





    }
}

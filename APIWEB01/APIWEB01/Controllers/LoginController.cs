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

                    context.REGISTRARCUENTA_SP(entidad.Identificacion, entidad.Nombre, entidad.Correo, entidad.Contrasena, entidad.Direccion, entidad.Estado); //Con SP(Procedimiento Almacenamiento)
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
                        string urlHtml = @"C:\Users\jarod\OneDrive\Escritorio\3Q-2023-Fide\PrograAvanzada-Miercoles\Email.html";
                        string html = File.ReadAllText(urlHtml);
                        EnvioCorreos(datos.Correo, "Recuperar Contraseña", html);
                    }
                        
                }
                return "OK";
            }
            catch(Exception e)
            {
                return e.Message;
            }
             

        }


        private void EnvioCorreos(string destino, string asunto, string contenido)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("testing000281@gmail.com");
            mailMessage.To.Add(new MailAddress(destino));
            mailMessage.Subject = asunto;
            mailMessage.Body = contenido;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient();// Servidor de correo
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("testing000281@gmail.com", "ojoz oxbt ixzv olra");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(mailMessage);

        }

    }
}

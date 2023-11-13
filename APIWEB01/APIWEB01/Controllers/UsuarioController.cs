using APIWEB01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWEB01.Controllers
{
    public class UsuarioController : ApiController
    {

        [HttpGet]
        [Route("ConsultarProvincias")]
        public List<System.Web.Mvc.SelectListItem> ConsultarProvincias()
        {
            try {
                using (var context = new DBMN())
                {
                    var datos = (from x in context.TProvincia
                                 select x).ToList();

                    var respuesta = new List<System.Web.Mvc.SelectListItem>();
                    foreach (var item in datos)
                    {

                        respuesta.Add(new System.Web.Mvc.SelectListItem { Value = item.ConProvincia.ToString(), Text = item.Descripcion });

                    }

                    return respuesta;


                }
            } catch(Exception) {

                return new List<System.Web.Mvc.SelectListItem>();            }
            
        }


        [HttpGet]
        [Route("ConsultarUsuarios")]
        public List<TUsuarios> ConsultarUsuarios()
        {
            try
            {
                using (var context = new DBMN())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.TUsuarios
                                 select x).ToList();

                    return datos;

                }
            }
            catch (Exception)
            {
                return new List<TUsuarios>();
            }

        }

        [HttpGet]
        [Route("ConsultaUsuario")]
        public TUsuarios ConsultaUsuario(long ConUsuario) //Consulta por URL ejemplo htttp://...?ConUsuario=12
        {
            try
            {
                using (var context = new DBMN())
                {
                    context.Configuration.LazyLoadingEnabled = false;//No trar las llaves foraneas
                    return (from x in context.TUsuarios
                                where x.ConUsuario == ConUsuario
                                select x).FirstOrDefault();

                   

                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        [HttpPut]
        [Route("ActualizarEstadoUsuario")]
        public string ActualizarEstadoUsuario(UsuarioEnt entidad) {

            try
            {
                using (var context = new DBMN())
                {
                    var datos = (from x in context.TUsuarios
                                 where x.ConUsuario == entidad.ConUsuario
                                 select x).FirstOrDefault();
                    if (datos != null) {

                        datos.Estado = (datos.Estado == true ? false : true);
                        context.SaveChanges();
                    
                    }

                    return "OK";

                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }

    

}

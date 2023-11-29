using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIWEB01;

namespace APIWEB01.Controllers
{
    public class TProductoController : ApiController
    {


        [HttpGet]
        [Route("ConsultarProductos")]
        public List<TProducto> ConsultarProductos()
        {
            using (var context = new DBMN()) {
                context.Configuration.LazyLoadingEnabled = false;
                return context.TProducto.ToList();
            }
                
        }


        [HttpGet]
        [Route("ConsultaProducto")]
        public TProducto ConsultaProducto(long ConProducto)
        {
            using (var context = new DBMN())
            {
                context.Configuration.LazyLoadingEnabled = false;
                return context.TProducto.FirstOrDefault(x=>x.ConProducto== ConProducto);
            }

        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public string EliminarProducto(long ConProducto) {
            using (var context = new DBMN()) {
                var entityToDelete = context.TProducto.SingleOrDefault(x => x.ConProducto== ConProducto);

                if (entityToDelete != null)
                {
                    context.TProducto.Remove(entityToDelete);
                    context.SaveChanges();
                }
                return "OK";

            }
        }


        [HttpPost]
        [Route("RegistrarProducto")]
        public long RegistrarProducto(TProducto tProducto)
        {

            using (var context = new DBMN()) { 
            
                context.TProducto.Add(tProducto);
                context.SaveChanges();
                return tProducto.ConProducto;//Retornsa el ID del producto creado
            }
               
        }

        [HttpPut]
        [Route("ActualizarRutaImagen")]
        public string ActualizarRutaImagen(TProducto tProducto)
        {

            using (var context = new DBMN())
            {
                var datos = context.TProducto.FirstOrDefault(x => x.ConProducto == tProducto.ConProducto);//Se puede hacer con esta funcion tambien


                //var datos = (from x in context.TProducto
                //             where x.ConProducto == tProducto.ConProducto
                //             select x).FirstOrDefault();

                if (datos != null) {
                    datos.Imagen = tProducto.Imagen;
                    context.SaveChanges();
                }
                return "OK";
            }

        }

        [HttpPut]
        [Route("ActualizarEstadoProducto")]
        public string ActualizarEstadoProducto(TProducto tProducto) {

            using (var context = new DBMN())
            {
                var datos = context.TProducto.Where(x => x.ConProducto == tProducto.ConProducto).FirstOrDefault();
                datos.Estado = datos.Estado ? false : true;
                context.SaveChanges();
                return "OK";
            }

        }

        [HttpPut]
        [Route("ActualizarProducto")]
        public string ActualizarProducto(TProducto tProducto) {

            using (var context = new DBMN())
            {

                TProducto producto = context.TProducto.SingleOrDefault(x => x.ConProducto == tProducto.ConProducto);

                if (tProducto != null)
                {
                    producto.Imagen = tProducto.Imagen;
                }
                
                producto.Nombre = tProducto.Nombre;
                producto.Descripcion = tProducto.Descripcion;
                producto.Cantidad = tProducto.Cantidad;
                producto.Precio = tProducto.Precio;
                producto.Estado = tProducto.Estado;
                
                context.SaveChanges();
                return "OK";
            }


        }


    }
}
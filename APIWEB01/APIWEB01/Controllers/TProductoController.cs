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


        // GET: api/TProducto

        [HttpGet]
        [Route("ConsultarProductos")]
        public List<TProducto> ConsultarProductos()
        {
            using (var context = new DBMN()) {
                context.Configuration.LazyLoadingEnabled = false;
                return context.TProducto.ToList();
            }
                
        }
        /*
        // GET: api/TProducto/5
        [ResponseType(typeof(TProducto))]
        public IHttpActionResult GetTProducto(long id)
        {
            TProducto tProducto = db.TProducto.Find(id);
            if (tProducto == null)
            {
                return NotFound();
            }

            return Ok(tProducto);
        }

        // PUT: api/TProducto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTProducto(long id, TProducto tProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tProducto.ConProducto)
            {
                return BadRequest();
            }

            db.Entry(tProducto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }*/


        // POST: api/TProducto
        [HttpPost]
        [Route("RegistrarProducto")]
        public string RegistrarProducto(TProducto tProducto)
        {

            using (var context = new DBMN()) { 
            
                context.TProducto.Add(tProducto);
                context.SaveChanges();
                return "OK";
            }
               
        }


        /*
        // DELETE: api/TProducto/5
        [ResponseType(typeof(TProducto))]
        public IHttpActionResult DeleteTProducto(long id)
        {
            TProducto tProducto = db.TProducto.Find(id);
            if (tProducto == null)
            {
                return NotFound();
            }

            db.TProducto.Remove(tProducto);
            db.SaveChanges();

            return Ok(tProducto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TProductoExists(long id)
        {
            return db.TProducto.Count(e => e.ConProducto == id) > 0;
        }
        */
    }
}
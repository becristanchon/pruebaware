using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using facturacion.Models;

namespace facturacion.Controllers
{

   public class productosController : ApiController
    {
        private OpheliaFacturacionEntities db = new OpheliaFacturacionEntities();

        /*   // GET: api/productos
           public IQueryable<p_productos> Getp_productos()
           {
               return db.p_productos;
           }*/


        [HttpGet]
        public IHttpActionResult productos()
        {

            List<p_productos> p_productos = db.p_productos.ToList();
            if (p_productos == null)
            {
                return NotFound();
            }

            return Ok(p_productos);
        }



        //[HttpGet]
        //public HttpResponseMessage Getp_productos()
        //{
        //    try
        //    {
        //        var result = db.p_productos.ToList();
        //        return Request.CreateResponse(result);
        //    }
        //    catch (Exception err)
        //    {
        //        throw err;
        //    }
        //}




        // GET: api/productos/5
        [ResponseType(typeof(p_productos))]
        public IHttpActionResult Getp_productos(int id)
        {
            p_productos p_productos = db.p_productos.Find(id);
            if (p_productos == null)
            {
                return NotFound();
            }

            return Ok(p_productos);
        }

        // PUT: api/productos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putp_productos(int id, p_productos p_productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_productos.pk_id_producto)
            {
                return BadRequest();
            }

            db.Entry(p_productos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!p_productosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/productos
        [ResponseType(typeof(p_productos))]
        public IHttpActionResult Postp_productos(p_productos p_productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.p_productos.Add(p_productos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_productos.pk_id_producto }, p_productos);
        }

        // DELETE: api/productos/5
        [ResponseType(typeof(p_productos))]
        public IHttpActionResult Deletep_productos(int id)
        {
            p_productos p_productos = db.p_productos.Find(id);
            if (p_productos == null)
            {
                return NotFound();
            }

            db.p_productos.Remove(p_productos);
            db.SaveChanges();

            return Ok(p_productos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool p_productosExists(int id)
        {
            return db.p_productos.Count(e => e.pk_id_producto == id) > 0;
        }
    }
}
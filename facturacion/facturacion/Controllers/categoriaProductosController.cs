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


   
    public class categoriaProductosController : ApiController
    {
        private OpheliaFacturacionEntities db = new OpheliaFacturacionEntities();

        // GET: api/categoriaProductos
        public IQueryable<c_categoria_productos> Getc_categoria_productos()
        {
            return db.c_categoria_productos;
        }

        // GET: api/categoriaProductos/5
        [ResponseType(typeof(c_categoria_productos))]
        public IHttpActionResult Getc_categoria_productos(int id)
        {
            c_categoria_productos c_categoria_productos = db.c_categoria_productos.Find(id);
            if (c_categoria_productos == null)
            {
                return NotFound();
            }

            return Ok(c_categoria_productos);
        }

        // PUT: api/categoriaProductos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putc_categoria_productos(int id, c_categoria_productos c_categoria_productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != c_categoria_productos.pk_id_categoria)
            {
                return BadRequest();
            }

            db.Entry(c_categoria_productos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!c_categoria_productosExists(id))
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

        // POST: api/categoriaProductos
        [ResponseType(typeof(c_categoria_productos))]
        public IHttpActionResult Postc_categoria_productos(c_categoria_productos c_categoria_productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.c_categoria_productos.Add(c_categoria_productos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = c_categoria_productos.pk_id_categoria }, c_categoria_productos);
        }

        // DELETE: api/categoriaProductos/5
        [ResponseType(typeof(c_categoria_productos))]
        public IHttpActionResult Deletec_categoria_productos(int id)
        {
            c_categoria_productos c_categoria_productos = db.c_categoria_productos.Find(id);
            if (c_categoria_productos == null)
            {
                return NotFound();
            }

            db.c_categoria_productos.Remove(c_categoria_productos);
            db.SaveChanges();

            return Ok(c_categoria_productos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool c_categoria_productosExists(int id)
        {
            return db.c_categoria_productos.Count(e => e.pk_id_categoria == id) > 0;
        }
    }
}

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using facturacion.Models;

namespace facturacion.Controllers
{ 

    public class facturasController : ApiController
    {
        private OpheliaFacturacionEntities db = new OpheliaFacturacionEntities();

        // GET: api/facturas
        public IQueryable<p_facturas> Getp_facturas()
        {
            return db.p_facturas;
        }

        // GET: api/facturas/5
        [ResponseType(typeof(p_facturas))]
        public IHttpActionResult Getp_facturas(int id)
        {
            p_facturas p_facturas = db.p_facturas.Find(id);
            if (p_facturas == null)
            {
                return NotFound();
            }

            return Ok(p_facturas);
        }

        // PUT: api/facturas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putp_facturas(int id, p_facturas p_facturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_facturas.pk_id_factura)
            {
                return BadRequest();
            }

            db.Entry(p_facturas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!p_facturasExists(id))
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

        // POST: api/facturas
        [ResponseType(typeof(p_facturas))]
        public IHttpActionResult Postp_facturas(p_facturas p_facturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.p_facturas.Add(p_facturas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_facturas.pk_id_factura }, p_facturas);
        }

        // DELETE: api/facturas/5
        [ResponseType(typeof(p_facturas))]
        public IHttpActionResult Deletep_facturas(int id)
        {
            p_facturas p_facturas = db.p_facturas.Find(id);
            if (p_facturas == null)
            {
                return NotFound();
            }

            db.p_facturas.Remove(p_facturas);
            db.SaveChanges();

            return Ok(p_facturas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool p_facturasExists(int id)
        {
            return db.p_facturas.Count(e => e.pk_id_factura == id) > 0;
        }
    }
}
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

  
    public class tipoDocumentoController : ApiController
    {
        private OpheliaFacturacionEntities db = new OpheliaFacturacionEntities();

        // GET: api/tipoDocumento
        public IQueryable<c_tipo_documento> Getc_tipo_documento()
        {
            return db.c_tipo_documento;
        }

        // GET: api/tipoDocumento/5
        [ResponseType(typeof(c_tipo_documento))]
        public IHttpActionResult Getc_tipo_documento(int id)
        {
            c_tipo_documento c_tipo_documento = db.c_tipo_documento.Find(id);
            if (c_tipo_documento == null)
            {
                return NotFound();
            }

            return Ok(c_tipo_documento);
        }

        // PUT: api/tipoDocumento/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putc_tipo_documento(int id, c_tipo_documento c_tipo_documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != c_tipo_documento.pk_id_tipodocumento)
            {
                return BadRequest();
            }

            db.Entry(c_tipo_documento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!c_tipo_documentoExists(id))
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

        // POST: api/tipoDocumento
        [ResponseType(typeof(c_tipo_documento))]
        public IHttpActionResult Postc_tipo_documento(c_tipo_documento c_tipo_documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.c_tipo_documento.Add(c_tipo_documento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = c_tipo_documento.pk_id_tipodocumento }, c_tipo_documento);
        }

        // DELETE: api/tipoDocumento/5
        [ResponseType(typeof(c_tipo_documento))]
        public IHttpActionResult Deletec_tipo_documento(int id)
        {
            c_tipo_documento c_tipo_documento = db.c_tipo_documento.Find(id);
            if (c_tipo_documento == null)
            {
                return NotFound();
            }

            db.c_tipo_documento.Remove(c_tipo_documento);
            db.SaveChanges();

            return Ok(c_tipo_documento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool c_tipo_documentoExists(int id)
        {
            return db.c_tipo_documento.Count(e => e.pk_id_tipodocumento == id) > 0;
        }
    }
}
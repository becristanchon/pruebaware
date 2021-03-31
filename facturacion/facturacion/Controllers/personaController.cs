using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using facturacion.Models;
using System.Web.Http.Cors;
using System.Web.Http;

namespace facturacion.Controllers
{


    public class personaController : ApiController
    {

      
        private OpheliaFacturacionEntities db = new OpheliaFacturacionEntities();

        // GET: api/persona
        public IQueryable<p_persona> Getp_persona()
        {
            return db.p_persona;
        }

        // GET: api/persona/5
        [ResponseType(typeof(p_persona))]
        public IHttpActionResult Getp_persona(int id)
        {
            p_persona p_persona = db.p_persona.Find(id);
            if (p_persona == null)
            {
                return NotFound();
            }

            return Ok(p_persona);
        }

        // PUT: api/persona/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putp_persona(int id, p_persona p_persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_persona.pk_id_persona)
            {
                return BadRequest();
            }

            db.Entry(p_persona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!p_personaExists(id))
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

        // POST: api/persona
        [ResponseType(typeof(p_persona))]
        public IHttpActionResult Postp_persona(p_persona p_persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.p_persona.Add(p_persona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = p_persona.pk_id_persona }, p_persona);
        }

        // DELETE: api/persona/5
        [ResponseType(typeof(p_persona))]
        public IHttpActionResult Deletep_persona(int id)
        {
            p_persona p_persona = db.p_persona.Find(id);
            if (p_persona == null)
            {
                return NotFound();
            }

            db.p_persona.Remove(p_persona);
            db.SaveChanges();

            return Ok(p_persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool p_personaExists(int id)
        {
            return db.p_persona.Count(e => e.pk_id_persona == id) > 0;
        }
    }
}
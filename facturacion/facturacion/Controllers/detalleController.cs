using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using facturacion.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace facturacion.Controllers
{
   
  
    public class detalleController : ApiController
    {
        private OpheliaFacturacionEntities db = new OpheliaFacturacionEntities();


        //[HttpGet]
        //public HttpResponseMessage Get()
        //{
        //    try
        //    {
        //        var result = db.p_persona.ToList();
        //        return Request.CreateResponse(result);
        //    }
        //    catch (Exception err)
        //    {
        //        throw err;
        //    }
        //}


        // GET: api/detalle/5

        [HttpGet]
        public IHttpActionResult Getp_detalle_factura()
        {
            List<p_detalle_factura> p_detalle_factura = db.p_detalle_factura.ToList();
            if (p_detalle_factura == null)
            {
                return NotFound();
            }

            return Ok(p_detalle_factura);
        }

     
        // GET: api/detalle/5
        [ResponseType(typeof(p_detalle_factura))]
        [HttpGet]
        public IHttpActionResult Getp_detalle_factura(int id)
        {
            p_detalle_factura p_detalle_factura = db.p_detalle_factura.Find(id);
            if (p_detalle_factura == null)
            {
                return NotFound();
            }

            return Ok(p_detalle_factura);
        }

        // PUT: api/detalle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putp_detalle_factura(int id, p_detalle_factura p_detalle_factura)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != p_detalle_factura.pk_id_detallefactura)
            {
                return BadRequest();
            }

            db.Entry(p_detalle_factura).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!p_detalle_facturaExists(id))
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

        [HttpPost]
        public HttpResponseMessage Insertdetalle(FormDataCollection form)
        {
            var values = form.Get("values");

            var detalle = new p_detalle_factura();
            JsonConvert.PopulateObject(values, detalle);

            Validate(detalle);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "");


            return Request.CreateResponse(HttpStatusCode.Created, detalle);
        }



        //// POST: api/detalle
        //[ResponseType(typeof(p_detalle_factura))]
        //public IHttpActionResult Postp_detalle_factura(p_detalle_factura p_detalle_factura)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.p_detalle_factura.Add(p_detalle_factura);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = p_detalle_factura.pk_id_detallefactura }, p_detalle_factura);
        //}

        // DELETE: api/detalle/5
        [ResponseType(typeof(p_detalle_factura))]
        public IHttpActionResult Deletep_detalle_factura(int id)
        {
            p_detalle_factura p_detalle_factura = db.p_detalle_factura.Find(id);
            if (p_detalle_factura == null)
            {
                return NotFound();
            }

            db.p_detalle_factura.Remove(p_detalle_factura);
            db.SaveChanges();

            return Ok(p_detalle_factura);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool p_detalle_facturaExists(int id)
        {
            return db.p_detalle_factura.Count(e => e.pk_id_detallefactura == id) > 0;
        }
    }
}
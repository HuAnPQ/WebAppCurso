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
using WebAppCurso.Models;

namespace WebAppCurso.Controllers
{
    public class SimulacionesController : ApiController
    {
        private Entities_FacciRentas db = new Entities_FacciRentas();

        // GET: api/Simulaciones
        public IQueryable<Simulacion> GetSimulacions()
        {
            return db.Simulacions.
                Where(s => s.PatrimonioFamiliar > 50000);
        }

        //// GET: api/Simulaciones
        //public IQueryable<Simulacion> GetSimulacions()
        //{
        //    return db.Simulacions;
        //}

        // GET: api/Simulaciones/5
        [ResponseType(typeof(Simulacion))]
        public IHttpActionResult GetSimulacion(int id)
        {
            Simulacion simulacion = db.Simulacions.Find(id);
            if (simulacion == null)
            {
                return NotFound();
            }

            return Ok(simulacion);
        }

        // PUT: api/Simulaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSimulacion(int id, Simulacion simulacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != simulacion.Id)
            {
                return BadRequest();
            }

            db.Entry(simulacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimulacionExists(id))
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

        // POST: api/Simulaciones
        [ResponseType(typeof(Simulacion))]
        public IHttpActionResult PostSimulacion(Simulacion simulacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Simulacions.Add(simulacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = simulacion.Id }, simulacion);
        }

        // DELETE: api/Simulaciones/5
        [ResponseType(typeof(Simulacion))]
        public IHttpActionResult DeleteSimulacion(int id)
        {
            Simulacion simulacion = db.Simulacions.Find(id);
            if (simulacion == null)
            {
                return NotFound();
            }

            db.Simulacions.Remove(simulacion);
            db.SaveChanges();

            return Ok(simulacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SimulacionExists(int id)
        {
            return db.Simulacions.Count(e => e.Id == id) > 0;
        }
    }
}
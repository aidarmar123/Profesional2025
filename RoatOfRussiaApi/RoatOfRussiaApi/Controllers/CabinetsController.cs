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
using RoatOfRussiaApi.Models;

namespace RoatOfRussiaApi.Controllers
{
    public class CabinetsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/Cabinets
        public IQueryable<Cabinet> GetCabinet()
        {
            return db.Cabinet;
        }

        // GET: api/Cabinets/5
        [ResponseType(typeof(Cabinet))]
        public IHttpActionResult GetCabinet(int id)
        {
            Cabinet cabinet = db.Cabinet.Find(id);
            if (cabinet == null)
            {
                return NotFound();
            }

            return Ok(cabinet);
        }

        // PUT: api/Cabinets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCabinet(int id, Cabinet cabinet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cabinet.Id)
            {
                return BadRequest();
            }

            db.Entry(cabinet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CabinetExists(id))
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

        // POST: api/Cabinets
        [ResponseType(typeof(Cabinet))]
        public IHttpActionResult PostCabinet(Cabinet cabinet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cabinet.Add(cabinet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CabinetExists(cabinet.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cabinet.Id }, cabinet);
        }

        // DELETE: api/Cabinets/5
        [ResponseType(typeof(Cabinet))]
        public IHttpActionResult DeleteCabinet(int id)
        {
            Cabinet cabinet = db.Cabinet.Find(id);
            if (cabinet == null)
            {
                return NotFound();
            }

            db.Cabinet.Remove(cabinet);
            db.SaveChanges();

            return Ok(cabinet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CabinetExists(int id)
        {
            return db.Cabinet.Count(e => e.Id == id) > 0;
        }
    }
}
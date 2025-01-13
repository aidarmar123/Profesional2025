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
    public class TypeEventsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/TypeEvents
        public IQueryable<TypeEvent> GetTypeEvent()
        {
            return db.TypeEvent;
        }

        // GET: api/TypeEvents/5
        [ResponseType(typeof(TypeEvent))]
        public IHttpActionResult GetTypeEvent(int id)
        {
            TypeEvent typeEvent = db.TypeEvent.Find(id);
            if (typeEvent == null)
            {
                return NotFound();
            }

            return Ok(typeEvent);
        }

        // PUT: api/TypeEvents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeEvent(int id, TypeEvent typeEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeEvent.Id)
            {
                return BadRequest();
            }

            db.Entry(typeEvent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeEventExists(id))
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

        // POST: api/TypeEvents
        [ResponseType(typeof(TypeEvent))]
        public IHttpActionResult PostTypeEvent(TypeEvent typeEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeEvent.Add(typeEvent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeEvent.Id }, typeEvent);
        }

        // DELETE: api/TypeEvents/5
        [ResponseType(typeof(TypeEvent))]
        public IHttpActionResult DeleteTypeEvent(int id)
        {
            TypeEvent typeEvent = db.TypeEvent.Find(id);
            if (typeEvent == null)
            {
                return NotFound();
            }

            db.TypeEvent.Remove(typeEvent);
            db.SaveChanges();

            return Ok(typeEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeEventExists(int id)
        {
            return db.TypeEvent.Count(e => e.Id == id) > 0;
        }
    }
}
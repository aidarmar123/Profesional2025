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
    public class EventResponsiblePersonsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/EventResponsiblePersons
        public IQueryable<EventResponsiblePerson> GetEventResponsiblePerson()
        {
            return db.EventResponsiblePerson;
        }

        // GET: api/EventResponsiblePersons/5
        [ResponseType(typeof(EventResponsiblePerson))]
        public IHttpActionResult GetEventResponsiblePerson(int id)
        {
            EventResponsiblePerson eventResponsiblePerson = db.EventResponsiblePerson.Find(id);
            if (eventResponsiblePerson == null)
            {
                return NotFound();
            }

            return Ok(eventResponsiblePerson);
        }

        // PUT: api/EventResponsiblePersons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventResponsiblePerson(int id, EventResponsiblePerson eventResponsiblePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventResponsiblePerson.Id)
            {
                return BadRequest();
            }

            db.Entry(eventResponsiblePerson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventResponsiblePersonExists(id))
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

        // POST: api/EventResponsiblePersons
        [ResponseType(typeof(EventResponsiblePerson))]
        public IHttpActionResult PostEventResponsiblePerson(EventResponsiblePerson eventResponsiblePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventResponsiblePerson.Add(eventResponsiblePerson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventResponsiblePerson.Id }, eventResponsiblePerson);
        }

        // DELETE: api/EventResponsiblePersons/5
        [ResponseType(typeof(EventResponsiblePerson))]
        public IHttpActionResult DeleteEventResponsiblePerson(int id)
        {
            EventResponsiblePerson eventResponsiblePerson = db.EventResponsiblePerson.Find(id);
            if (eventResponsiblePerson == null)
            {
                return NotFound();
            }

            db.EventResponsiblePerson.Remove(eventResponsiblePerson);
            db.SaveChanges();

            return Ok(eventResponsiblePerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventResponsiblePersonExists(int id)
        {
            return db.EventResponsiblePerson.Count(e => e.Id == id) > 0;
        }
    }
}
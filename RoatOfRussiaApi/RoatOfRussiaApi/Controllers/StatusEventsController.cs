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
    public class StatusEventsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/StatusEvents
        public IQueryable<StatusEvent> GetStatusEvent()
        {
            return db.StatusEvent;
        }

        // GET: api/StatusEvents/5
        [ResponseType(typeof(StatusEvent))]
        public IHttpActionResult GetStatusEvent(int id)
        {
            StatusEvent statusEvent = db.StatusEvent.Find(id);
            if (statusEvent == null)
            {
                return NotFound();
            }

            return Ok(statusEvent);
        }

        // PUT: api/StatusEvents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusEvent(int id, StatusEvent statusEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusEvent.Id)
            {
                return BadRequest();
            }

            db.Entry(statusEvent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusEventExists(id))
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

        // POST: api/StatusEvents
        [ResponseType(typeof(StatusEvent))]
        public IHttpActionResult PostStatusEvent(StatusEvent statusEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusEvent.Add(statusEvent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusEvent.Id }, statusEvent);
        }

        // DELETE: api/StatusEvents/5
        [ResponseType(typeof(StatusEvent))]
        public IHttpActionResult DeleteStatusEvent(int id)
        {
            StatusEvent statusEvent = db.StatusEvent.Find(id);
            if (statusEvent == null)
            {
                return NotFound();
            }

            db.StatusEvent.Remove(statusEvent);
            db.SaveChanges();

            return Ok(statusEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusEventExists(int id)
        {
            return db.StatusEvent.Count(e => e.Id == id) > 0;
        }
    }
}
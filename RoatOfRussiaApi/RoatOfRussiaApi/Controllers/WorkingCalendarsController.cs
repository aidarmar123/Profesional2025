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
    public class WorkingCalendarsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/WorkingCalendars
        public IQueryable<WorkingCalendar> GetWorkingCalendar()
        {
            return db.WorkingCalendar;
        }

        // GET: api/WorkingCalendars/5
        [ResponseType(typeof(WorkingCalendar))]
        public IHttpActionResult GetWorkingCalendar(long id)
        {
            WorkingCalendar workingCalendar = db.WorkingCalendar.Find(id);
            if (workingCalendar == null)
            {
                return NotFound();
            }

            return Ok(workingCalendar);
        }

        // PUT: api/WorkingCalendars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkingCalendar(long id, WorkingCalendar workingCalendar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workingCalendar.Id)
            {
                return BadRequest();
            }

            db.Entry(workingCalendar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkingCalendarExists(id))
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

        // POST: api/WorkingCalendars
        [ResponseType(typeof(WorkingCalendar))]
        public IHttpActionResult PostWorkingCalendar(WorkingCalendar workingCalendar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkingCalendar.Add(workingCalendar);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (WorkingCalendarExists(workingCalendar.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = workingCalendar.Id }, workingCalendar);
        }

        // DELETE: api/WorkingCalendars/5
        [ResponseType(typeof(WorkingCalendar))]
        public IHttpActionResult DeleteWorkingCalendar(long id)
        {
            WorkingCalendar workingCalendar = db.WorkingCalendar.Find(id);
            if (workingCalendar == null)
            {
                return NotFound();
            }

            db.WorkingCalendar.Remove(workingCalendar);
            db.SaveChanges();

            return Ok(workingCalendar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkingCalendarExists(long id)
        {
            return db.WorkingCalendar.Count(e => e.Id == id) > 0;
        }
    }
}
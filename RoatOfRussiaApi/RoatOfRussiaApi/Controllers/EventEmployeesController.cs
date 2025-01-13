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
    public class EventEmployeesController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/EventEmployees
        public IQueryable<EventEmployee> GetEventEmployee()
        {
            return db.EventEmployee;
        }

        // GET: api/EventEmployees/5
        [ResponseType(typeof(EventEmployee))]
        public IHttpActionResult GetEventEmployee(int id)
        {
            EventEmployee eventEmployee = db.EventEmployee.Find(id);
            if (eventEmployee == null)
            {
                return NotFound();
            }

            return Ok(eventEmployee);
        }

        // PUT: api/EventEmployees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventEmployee(int id, EventEmployee eventEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventEmployee.Id)
            {
                return BadRequest();
            }

            db.Entry(eventEmployee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventEmployeeExists(id))
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

        // POST: api/EventEmployees
        [ResponseType(typeof(EventEmployee))]
        public IHttpActionResult PostEventEmployee(EventEmployee eventEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventEmployee.Add(eventEmployee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventEmployee.Id }, eventEmployee);
        }

        // DELETE: api/EventEmployees/5
        [ResponseType(typeof(EventEmployee))]
        public IHttpActionResult DeleteEventEmployee(int id)
        {
            EventEmployee eventEmployee = db.EventEmployee.Find(id);
            if (eventEmployee == null)
            {
                return NotFound();
            }

            db.EventEmployee.Remove(eventEmployee);
            db.SaveChanges();

            return Ok(eventEmployee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventEmployeeExists(int id)
        {
            return db.EventEmployee.Count(e => e.Id == id) > 0;
        }
    }
}
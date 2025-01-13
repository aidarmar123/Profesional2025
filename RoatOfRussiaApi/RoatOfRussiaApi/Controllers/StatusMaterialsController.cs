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
    public class StatusMaterialsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/StatusMaterials
        public IQueryable<StatusMaterial> GetStatusMaterial()
        {
            return db.StatusMaterial;
        }

        // GET: api/StatusMaterials/5
        [ResponseType(typeof(StatusMaterial))]
        public IHttpActionResult GetStatusMaterial(int id)
        {
            StatusMaterial statusMaterial = db.StatusMaterial.Find(id);
            if (statusMaterial == null)
            {
                return NotFound();
            }

            return Ok(statusMaterial);
        }

        // PUT: api/StatusMaterials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusMaterial(int id, StatusMaterial statusMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusMaterial.Id)
            {
                return BadRequest();
            }

            db.Entry(statusMaterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusMaterialExists(id))
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

        // POST: api/StatusMaterials
        [ResponseType(typeof(StatusMaterial))]
        public IHttpActionResult PostStatusMaterial(StatusMaterial statusMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusMaterial.Add(statusMaterial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusMaterial.Id }, statusMaterial);
        }

        // DELETE: api/StatusMaterials/5
        [ResponseType(typeof(StatusMaterial))]
        public IHttpActionResult DeleteStatusMaterial(int id)
        {
            StatusMaterial statusMaterial = db.StatusMaterial.Find(id);
            if (statusMaterial == null)
            {
                return NotFound();
            }

            db.StatusMaterial.Remove(statusMaterial);
            db.SaveChanges();

            return Ok(statusMaterial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusMaterialExists(int id)
        {
            return db.StatusMaterial.Count(e => e.Id == id) > 0;
        }
    }
}
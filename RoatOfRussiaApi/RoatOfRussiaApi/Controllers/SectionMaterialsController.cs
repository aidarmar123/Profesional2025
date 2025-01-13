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
    public class SectionMaterialsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/SectionMaterials
        public IQueryable<SectionMaterial> GetSectionMaterial()
        {
            return db.SectionMaterial;
        }

        // GET: api/SectionMaterials/5
        [ResponseType(typeof(SectionMaterial))]
        public IHttpActionResult GetSectionMaterial(int id)
        {
            SectionMaterial sectionMaterial = db.SectionMaterial.Find(id);
            if (sectionMaterial == null)
            {
                return NotFound();
            }

            return Ok(sectionMaterial);
        }

        // PUT: api/SectionMaterials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSectionMaterial(int id, SectionMaterial sectionMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sectionMaterial.Id)
            {
                return BadRequest();
            }

            db.Entry(sectionMaterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionMaterialExists(id))
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

        // POST: api/SectionMaterials
        [ResponseType(typeof(SectionMaterial))]
        public IHttpActionResult PostSectionMaterial(SectionMaterial sectionMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SectionMaterial.Add(sectionMaterial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sectionMaterial.Id }, sectionMaterial);
        }

        // DELETE: api/SectionMaterials/5
        [ResponseType(typeof(SectionMaterial))]
        public IHttpActionResult DeleteSectionMaterial(int id)
        {
            SectionMaterial sectionMaterial = db.SectionMaterial.Find(id);
            if (sectionMaterial == null)
            {
                return NotFound();
            }

            db.SectionMaterial.Remove(sectionMaterial);
            db.SaveChanges();

            return Ok(sectionMaterial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SectionMaterialExists(int id)
        {
            return db.SectionMaterial.Count(e => e.Id == id) > 0;
        }
    }
}
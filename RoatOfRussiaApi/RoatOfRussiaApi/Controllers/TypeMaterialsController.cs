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
    public class TypeMaterialsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        // GET: api/TypeMaterials
        public IQueryable<TypeMaterial> GetTypeMaterial()
        {
            return db.TypeMaterial;
        }

        // GET: api/TypeMaterials/5
        [ResponseType(typeof(TypeMaterial))]
        public IHttpActionResult GetTypeMaterial(int id)
        {
            TypeMaterial typeMaterial = db.TypeMaterial.Find(id);
            if (typeMaterial == null)
            {
                return NotFound();
            }

            return Ok(typeMaterial);
        }

        // PUT: api/TypeMaterials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeMaterial(int id, TypeMaterial typeMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeMaterial.Id)
            {
                return BadRequest();
            }

            db.Entry(typeMaterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeMaterialExists(id))
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

        // POST: api/TypeMaterials
        [ResponseType(typeof(TypeMaterial))]
        public IHttpActionResult PostTypeMaterial(TypeMaterial typeMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeMaterial.Add(typeMaterial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeMaterial.Id }, typeMaterial);
        }

        // DELETE: api/TypeMaterials/5
        [ResponseType(typeof(TypeMaterial))]
        public IHttpActionResult DeleteTypeMaterial(int id)
        {
            TypeMaterial typeMaterial = db.TypeMaterial.Find(id);
            if (typeMaterial == null)
            {
                return NotFound();
            }

            db.TypeMaterial.Remove(typeMaterial);
            db.SaveChanges();

            return Ok(typeMaterial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeMaterialExists(int id)
        {
            return db.TypeMaterial.Count(e => e.Id == id) > 0;
        }
    }
}
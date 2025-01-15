using RoatOfRussiaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RoatOfRussiaApi.Controllers
{
    public class DocumentsController : ApiController
    {
        private RoatOfRussiaEntities db = new RoatOfRussiaEntities();

        [HttpGet]
        [Route("api/v1/Documents")]
        public IHttpActionResult GetDocuments()
        {
            if (db.Material.Count() != 0)
            {
                return Ok(db.Material.ToList());
            }
            else
            {
                return StatusCode(HttpStatusCode.NotFound);
            }


        }
        [HttpGet]
        [Route("api/v1/Documents/{documentId}/Comments")]
        public IHttpActionResult GetComment(int documentId)
        {
            if (db.Material.Count() != 0)
            {
                return Ok(db.Material.ToList());
            }
            else
            {
                return StatusCode(HttpStatusCode.NotFound);
            }


        }
    }
}

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
using Microsoft.AspNetCore.Cors;
using MinMadOpskrift;

namespace MinMadOpskrift.Controllers
{
    [Route("api/Opskrifts")]
    public class OpskriftsController : ApiController
    {
        private MinMadOpskriftEntities3 db = new MinMadOpskriftEntities3();

        // GET: api/Opskrifts
        [HttpGet]
        public IQueryable<Opskrift> GetOpskrift()
        {
            return db.Opskrift;
        }

        // GET: api/Opskrifts/5
        [ResponseType(typeof(Opskrift))]
        [HttpGet]
        [Route("api/Opskrifts/{id}")]

        public IHttpActionResult GetOpskrift(int id)
        {

            Opskrift opskrift = db.Opskrift.Find(id);
            if (opskrift == null)
            {
                return NotFound();
            }

            return Ok(opskrift);
        }

        // PUT: api/Opskrifts/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOpskrift(int id, Opskrift opskrift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != opskrift.ID)
            {
                return BadRequest();
            }

            db.Entry(opskrift).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OpskriftExists(id))
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

        // POST: api/Opskrifts
        [HttpPost]
        [ResponseType(typeof(Opskrift))]
        public IHttpActionResult PostOpskrift(Opskrift opskrift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Opskrift.Add(opskrift);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = opskrift.ID }, opskrift);
        }

        // DELETE: api/Opskrifts/5
        [ResponseType(typeof(Opskrift))]
        [HttpDelete]
        [Route("api/Opskrifts/{id}")]
        public IHttpActionResult DeleteOpskrift(int id)
        {
            Opskrift opskrift = db.Opskrift.Find(id);
            if (opskrift == null)
            {
                return NotFound();
            }

            db.Opskrift.Remove(opskrift);
            db.SaveChanges();

            return Ok(opskrift);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OpskriftExists(int id)
        {
            return db.Opskrift.Count(e => e.ID == id) > 0;
        }
    }
}
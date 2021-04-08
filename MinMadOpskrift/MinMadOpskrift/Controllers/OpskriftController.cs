using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MinMadOpskrift;

namespace MinMadOpskrift.Controllers
{
    [Route("api/Opskrift")]
    public class OpskriftController : ApiController
    {
        private MinMadOpskriftEntities db = new MinMadOpskriftEntities();

        // GET: api/Opskrift
        public IQueryable<Opskrift> GetOpskrift()
        {
            return db.Opskrift;
        }

        // GET: api/Opskrift/5
        [ResponseType(typeof(Opskrift))]
        public IHttpActionResult GetOpskrift(int id)
        {
            Opskrift opskrift = db.Opskrift.Find(id);
            if (opskrift == null)
            {
                return NotFound();
            }

            return Ok(opskrift);
        }

        // PUT: api/Opskrift/5
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

        // POST: api/Opskrift
        [ResponseType(typeof(Opskrift))]
        public IHttpActionResult PostOpskrift(Opskrift opskrift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                db.Opskrift.Add(opskrift);
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = opskrift.ID }, opskrift);
        }

        // DELETE: api/Opskrift/5
        [ResponseType(typeof(Opskrift))]
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
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
using MinMadOpskrift;

namespace MinMadOpskrift.Controllers
{
    [Route("api/Bruger")]
    public class BrugerController : ApiController
    {
        private MinMadOpskriftEntities db = new MinMadOpskriftEntities();

        // GET: api/Bruger
        public IQueryable<Bruger> GetBruger()
        {
            return db.Bruger;
        }

        // GET: api/Bruger/5
        [ResponseType(typeof(Bruger))]
        public IHttpActionResult GetBruger(int id)
        {
            Bruger bruger = db.Bruger.Find(id);
            if (bruger == null)
            {
                return NotFound();
            }

            return Ok(bruger);
        }

        // PUT: api/Bruger/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBruger(int id, Bruger bruger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bruger.ID)
            {
                return BadRequest();
            }

            db.Entry(bruger).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrugerExists(id))
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

        // POST: api/Bruger
        [ResponseType(typeof(Bruger))]
        public IHttpActionResult PostBruger(Bruger bruger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bruger.Add(bruger);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bruger.ID }, bruger);
        }

        // DELETE: api/Bruger/5
        [ResponseType(typeof(Bruger))]
        public IHttpActionResult DeleteBruger(int id)
        {
            Bruger bruger = db.Bruger.Find(id);
            if (bruger == null)
            {
                return NotFound();
            }

            db.Bruger.Remove(bruger);
            db.SaveChanges();

            return Ok(bruger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrugerExists(int id)
        {
            return db.Bruger.Count(e => e.ID == id) > 0;
        }
    }
}
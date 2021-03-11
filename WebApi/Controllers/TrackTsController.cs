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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class TrackTsController : ApiController
    {
        private DBAllphaModel db = new DBAllphaModel();

        // GET: api/TrackTs
        public IQueryable<TrackT> GetTrackT()
        {
            return db.TrackT;
        }

        // GET: api/TrackTs/5
        [ResponseType(typeof(TrackT))]
        public IHttpActionResult GetTrackT(int id)
        {
            TrackT trackT = db.TrackT.Find(id);
            if (trackT == null)
            {
                return NotFound();
            }

            return Ok(trackT);
        }

        // PUT: api/TrackTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrackT(int id, TrackT trackT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackT.id)
            {
                return BadRequest();
            }

            db.Entry(trackT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackTExists(id))
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

        // POST: api/TrackTs
        [ResponseType(typeof(TrackT))]
        public IHttpActionResult PostTrackT(TrackT trackT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TrackT.Add(trackT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trackT.id }, trackT);
        }

        // DELETE: api/TrackTs/5
        [ResponseType(typeof(TrackT))]
        public IHttpActionResult DeleteTrackT(int id)
        {
            TrackT trackT = db.TrackT.Find(id);
            if (trackT == null)
            {
                return NotFound();
            }

            db.TrackT.Remove(trackT);
            db.SaveChanges();

            return Ok(trackT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackTExists(int id)
        {
            return db.TrackT.Count(e => e.id == id) > 0;
        }
    }
}
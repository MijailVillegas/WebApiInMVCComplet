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
    public class TbAlbumsController : ApiController
    {
        private DBAllphaModel db = new DBAllphaModel();

        // GET: api/TbAlbums
        public IQueryable<TbAlbum> GetTbAlbum()
        {
            return db.TbAlbum;
        }

        // GET: api/TbAlbums/5
        [ResponseType(typeof(TbAlbum))]
        public IHttpActionResult GetTbAlbum(int id)
        {
            TbAlbum tbAlbum = db.TbAlbum.Find(id);
            if (tbAlbum == null)
            {
                return NotFound();
            }

            return Ok(tbAlbum);
        }

        // PUT: api/TbAlbums/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbAlbum(int id, TbAlbum tbAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbAlbum.id)
            {
                return BadRequest();
            }

            db.Entry(tbAlbum).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbAlbumExists(id))
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

        // POST: api/TbAlbums
        [ResponseType(typeof(TbAlbum))]
        public IHttpActionResult PostTbAlbum(TbAlbum tbAlbum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TbAlbum.Add(tbAlbum);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbAlbum.id }, tbAlbum);
        }

        // DELETE: api/TbAlbums/5
        [ResponseType(typeof(TbAlbum))]
        public IHttpActionResult DeleteTbAlbum(int id)
        {
            TbAlbum tbAlbum = db.TbAlbum.Find(id);
            if (tbAlbum == null)
            {
                return NotFound();
            }

            db.TbAlbum.Remove(tbAlbum);
            db.SaveChanges();

            return Ok(tbAlbum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TbAlbumExists(int id)
        {
            return db.TbAlbum.Count(e => e.id == id) > 0;
        }
    }
}
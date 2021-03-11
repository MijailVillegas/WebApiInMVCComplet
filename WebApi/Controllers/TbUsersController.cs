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
    public class TbUsersController : ApiController
    {
        private DBAllphaModel db = new DBAllphaModel();

        // GET: api/TbUsers
        public IQueryable<TbUser> GetTbUser()
        {
            return db.TbUser;
        }

        // GET: api/TbUsers/5
        [ResponseType(typeof(TbUser))]
        public IHttpActionResult GetTbUser(int id)
        {
            TbUser tbUser = db.TbUser.Find(id);
            if (tbUser == null)
            {
                return NotFound();
            }

            return Ok(tbUser);
        }

        // PUT: api/TbUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbUser(int id, TbUser tbUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbUser.usr_id)
            {
                return BadRequest();
            }

            db.Entry(tbUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbUserExists(id))
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

        // POST: api/TbUsers
        [ResponseType(typeof(TbUser))]
        public IHttpActionResult PostTbUser(TbUser tbUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TbUser.Add(tbUser);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbUser.usr_id }, tbUser);
        }

        // DELETE: api/TbUsers/5
        [ResponseType(typeof(TbUser))]
        public IHttpActionResult DeleteTbUser(int id)
        {
            TbUser tbUser = db.TbUser.Find(id);
            if (tbUser == null)
            {
                return NotFound();
            }

            db.TbUser.Remove(tbUser);
            db.SaveChanges();

            return Ok(tbUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TbUserExists(int id)
        {
            return db.TbUser.Count(e => e.usr_id == id) > 0;
        }
    }
}
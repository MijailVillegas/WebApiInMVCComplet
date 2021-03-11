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
    public class CompraTsController : ApiController
    {
        private DBAllphaModel db = new DBAllphaModel();

        // GET: api/CompraTs
        public IQueryable<CompraT> GetCompraT()
        {
            return db.CompraT;
        }

        // GET: api/CompraTs/5
        [ResponseType(typeof(CompraT))]
        public IHttpActionResult GetCompraT(int id)
        {
            CompraT compraT = db.CompraT.Find(id);
            if (compraT == null)
            {
                return NotFound();
            }

            return Ok(compraT);
        }

        // PUT: api/CompraTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompraT(int id, CompraT compraT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compraT.sell_id)
            {
                return BadRequest();
            }

            db.Entry(compraT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraTExists(id))
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

        // POST: api/CompraTs
        [ResponseType(typeof(CompraT))]
        public IHttpActionResult PostCompraT(CompraT compraT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompraT.Add(compraT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = compraT.sell_id }, compraT);
        }

        // DELETE: api/CompraTs/5
        [ResponseType(typeof(CompraT))]
        public IHttpActionResult DeleteCompraT(int id)
        {
            CompraT compraT = db.CompraT.Find(id);
            if (compraT == null)
            {
                return NotFound();
            }

            db.CompraT.Remove(compraT);
            db.SaveChanges();

            return Ok(compraT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompraTExists(int id)
        {
            return db.CompraT.Count(e => e.sell_id == id) > 0;
        }
    }
}
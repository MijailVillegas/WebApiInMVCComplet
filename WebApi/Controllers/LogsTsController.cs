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
    public class LogsTsController : ApiController
    {
        private DBAllphaModel db = new DBAllphaModel();

        // GET: api/LogsTs
        public IQueryable<LogsT> GetLogsT()
        {
            return db.LogsT;
        }

        // GET: api/LogsTs/5
        [ResponseType(typeof(LogsT))]
        public IHttpActionResult GetLogsT(int id)
        {
            LogsT logsT = db.LogsT.Find(id);
            if (logsT == null)
            {
                return NotFound();
            }

            return Ok(logsT);
        }

        // PUT: api/LogsTs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLogsT(int id, LogsT logsT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != logsT.id_log)
            {
                return BadRequest();
            }

            db.Entry(logsT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogsTExists(id))
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

        // POST: api/LogsTs
        [ResponseType(typeof(LogsT))]
        public IHttpActionResult PostLogsT(LogsT logsT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LogsT.Add(logsT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = logsT.id_log }, logsT);
        }

        // DELETE: api/LogsTs/5
        [ResponseType(typeof(LogsT))]
        public IHttpActionResult DeleteLogsT(int id)
        {
            LogsT logsT = db.LogsT.Find(id);
            if (logsT == null)
            {
                return NotFound();
            }

            db.LogsT.Remove(logsT);
            db.SaveChanges();

            return Ok(logsT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LogsTExists(int id)
        {
            return db.LogsT.Count(e => e.id_log == id) > 0;
        }
    }
}
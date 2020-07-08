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
using _07WebAPI.Models;

namespace _07WebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        private 教務系統Entities db = new 教務系統Entities();

        // GET: api/Students
        public IQueryable<學生> Get學生()
        {
            return db.學生;
        }

        // GET: api/Students/5
        [ResponseType(typeof(學生))]
        public IHttpActionResult Get學生(string id)
        {
            學生 學生 = db.學生.Find(id);
            if (學生 == null)
            {
                return NotFound();
            }

            return Ok(學生);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put學生(string id, 學生 學生)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != 學生.學號)
            {
                return BadRequest();
            }

            db.Entry(學生).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!學生Exists(id))
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

        // POST: api/Students
        [ResponseType(typeof(學生))]
        public IHttpActionResult Post學生(學生 學生)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.學生.Add(學生);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (學生Exists(學生.學號))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = 學生.學號 }, 學生);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(學生))]
        public IHttpActionResult Delete學生(string id)
        {
            學生 學生 = db.學生.Find(id);
            if (學生 == null)
            {
                return NotFound();
            }

            db.學生.Remove(學生);
            db.SaveChanges();

            return Ok(學生);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool 學生Exists(string id)
        {
            return db.學生.Count(e => e.學號 == id) > 0;
        }
    }
}
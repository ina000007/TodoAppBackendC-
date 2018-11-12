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
using TodoApp.Models;


namespace TodoApp.Controllers
{
    public class todo_stsController : ApiController
    {
        private Nishant_DBEntities db = new Nishant_DBEntities();

        // GET: api/todo_sts
        public IQueryable<todo_sts> Gettodo_sts()
        {
            return db.todo_sts;
        }

        // GET: api/todo_sts/5
        [ResponseType(typeof(todo_sts))]
        public IHttpActionResult Gettodo_sts(int id)
        {
            todo_sts todo_sts = db.todo_sts.Find(id);
            if (todo_sts == null)
            {
                return NotFound();
            }

            return Ok(todo_sts);
        }

        // PUT: api/todo_sts/5

        [ResponseType(typeof(void))]
        public IHttpActionResult Puttodo_sts(int id, todo_sts todo_sts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todo_sts.st_cd)
            {
                return BadRequest();
            }

            db.Entry(todo_sts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!todo_stsExists(id))
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

        // POST: api/todo_sts
        [ResponseType(typeof(todo_sts))]
        public IHttpActionResult Posttodo_sts(todo_sts todo_sts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.todo_sts.Add(todo_sts);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (todo_stsExists(todo_sts.st_cd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = todo_sts.st_cd }, todo_sts);
        }

        // DELETE: api/todo_sts/5
        [ResponseType(typeof(todo_sts))]
        public IHttpActionResult Deletetodo_sts(int id)
        {
            todo_sts todo_sts = db.todo_sts.Find(id);
            if (todo_sts == null)
            {
                return NotFound();
            }

            db.todo_sts.Remove(todo_sts);
            db.SaveChanges();

            return Ok(todo_sts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool todo_stsExists(int id)
        {
            return db.todo_sts.Count(e => e.st_cd == id) > 0;
        }
    }
}
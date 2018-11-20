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
    public class todo_typeController : ApiController
    {
        private Nishant_DBEntities db = new Nishant_DBEntities();

        // GET: api/todo_type
        public IQueryable<todo_type> Gettodo_type()
        {
            return db.todo_type;
        }

        // GET: api/todo_type/5
        [ResponseType(typeof(todo_type))]
        public IHttpActionResult Gettodo_type(int id)
        {
            todo_type todo_type = db.todo_type.Find(id);
            if (todo_type == null)
            {
                return NotFound();
            }

            return Ok(todo_type);
        }

        // PUT: api/todo_type/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttodo_type(int id, todo_type todo_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todo_type.todo_type_cd)
            {
                return BadRequest();
            }

            db.Entry(todo_type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!todo_typeExists(id))
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

        // POST: api/todo_type
        [ResponseType(typeof(todo_type))]
        public IHttpActionResult Posttodo_type(todo_type todo_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.todo_type.Add(todo_type);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (todo_typeExists(todo_type.todo_type_cd))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = todo_type.todo_type_cd }, todo_type);
        }

        // DELETE: api/todo_type/5
        [ResponseType(typeof(todo_type))]
        public IHttpActionResult Deletetodo_type(int id)
        {
            todo_type todo_type = db.todo_type.Find(id);
            if (todo_type == null)
            {
                return NotFound();
            }

            db.todo_type.Remove(todo_type);
            db.SaveChanges();

            return Ok(todo_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool todo_typeExists(int id)
        {
            return db.todo_type.Count(e => e.todo_type_cd == id) > 0;
        }
    }
}
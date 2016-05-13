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
using WebAPIplusEF;

namespace WebAPIplusEF.Controllers
{
    public class v_System_UserAPIController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/v_System_UserAPI
        public IQueryable<v_System_User> Getv_System_User()
        {
            return db.v_System_User;
        }

        // GET: api/v_System_UserAPI/5
        [ResponseType(typeof(v_System_User))]
        public IHttpActionResult Getv_System_User(int id)
        {
            v_System_User v_System_User = db.v_System_User.Find(id);
            if (v_System_User == null)
            {
                return NotFound();
            }

            return Ok(v_System_User);
        }

        // PUT: api/v_System_UserAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putv_System_User(int id, v_System_User v_System_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != v_System_User.ID)
            {
                return BadRequest();
            }

            db.Entry(v_System_User).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!v_System_UserExists(id))
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

        // POST: api/v_System_UserAPI
        [ResponseType(typeof(v_System_User))]
        public IHttpActionResult Postv_System_User(v_System_User v_System_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.v_System_User.Add(v_System_User);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (v_System_UserExists(v_System_User.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = v_System_User.ID }, v_System_User);
        }

        // DELETE: api/v_System_UserAPI/5
        [ResponseType(typeof(v_System_User))]
        public IHttpActionResult Deletev_System_User(int id)
        {
            v_System_User v_System_User = db.v_System_User.Find(id);
            if (v_System_User == null)
            {
                return NotFound();
            }

            db.v_System_User.Remove(v_System_User);
            db.SaveChanges();

            return Ok(v_System_User);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool v_System_UserExists(int id)
        {
            return db.v_System_User.Count(e => e.ID == id) > 0;
        }
    }
}
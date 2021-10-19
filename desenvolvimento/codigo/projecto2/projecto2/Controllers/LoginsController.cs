using projecto2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace projecto2.Controllers
{
    public class LoginsController : ApiController
    {
        private dbDsEntities db = new dbDsEntities();

        // GET: api/logins
        public IQueryable<login> Getlogins()
        {
            return db.logins;
        }

        // GET: api/logins/5
        [ResponseType(typeof(login))]
        public async Task<IHttpActionResult> Getlogin(int id)
        {
            login login = await db.logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/logins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putlogin(int id, login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.id_login)
            {
                return BadRequest();
            }

            db.Entry(login).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!loginExists(id))
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

        // POST: api/logins
        [ResponseType(typeof(login))]
        public async Task<IHttpActionResult> Postlogin(login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.logins.Add(login);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = login.id_login }, login);
        }

        // DELETE: api/logins/5
        [ResponseType(typeof(login))]
        public async Task<IHttpActionResult> Deletelogin(int id)
        {
            login login = await db.logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            db.logins.Remove(login);
            await db.SaveChangesAsync();

            return Ok(login);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool loginExists(int id)
        {
            return db.logins.Count(e => e.id_login == id) > 0;
        }
    }
}

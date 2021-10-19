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
using projecto2.Models;

namespace projecto2.Controllers
{
    public class ItemEmprestimoController : ApiController
    {
        private dbDsEntities db = new dbDsEntities();

        // GET: api/ItemEmprestimo
        public IQueryable<Details_Emprestimo> GetDetails_Emprestimo()
        {
            return db.Details_Emprestimo;
        }

        // GET: api/ItemEmprestimo/5
        [ResponseType(typeof(Details_Emprestimo))]
        public IHttpActionResult GetDetails_Emprestimo(int id)
        {
            Details_Emprestimo details_Emprestimo = db.Details_Emprestimo.Find(id);
            if (details_Emprestimo == null)
            {
                return NotFound();
            }

            return Ok(details_Emprestimo);
        }

        // PUT: api/ItemEmprestimo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetails_Emprestimo(int id, Details_Emprestimo details_Emprestimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != details_Emprestimo.id_Details_Empres)
            {
                return BadRequest();
            }

            db.Entry(details_Emprestimo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Details_EmprestimoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(details_Emprestimo);

            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ItemEmprestimo
        [ResponseType(typeof(Details_Emprestimo))]
        public IHttpActionResult PostDetails_Emprestimo(Details_Emprestimo details_Emprestimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Details_Emprestimo.Add(details_Emprestimo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = details_Emprestimo.id_Details_Empres }, details_Emprestimo);
        }

        // DELETE: api/ItemEmprestimo/5
        [ResponseType(typeof(Details_Emprestimo))]
        public IHttpActionResult DeleteDetails_Emprestimo(int id)
        {
            Details_Emprestimo details_Emprestimo = db.Details_Emprestimo.Find(id);
            if (details_Emprestimo == null)
            {
                return NotFound();
            }

            db.Details_Emprestimo.Remove(details_Emprestimo);
            db.SaveChanges();

            return Ok(details_Emprestimo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Details_EmprestimoExists(int id)
        {
            return db.Details_Emprestimo.Count(e => e.id_Details_Empres == id) > 0;
        }
    }
}
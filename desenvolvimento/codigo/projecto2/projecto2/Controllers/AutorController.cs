using projecto2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace projecto2.Controllers
{
    public class AutorController : ApiController
    {
        private dbDsEntities db = new dbDsEntities();

        // GET: api/Autores
        public IQueryable<Autore> GetAllAutores()
        {
            return db.Autores;
        }

        // GET: api/Autores/5
        [ResponseType(typeof(Autore))]
        public IHttpActionResult GetAutor(int id)
        {
            Autore autore = db.Autores.Find(id);
            if (autore == null)
            {
                return NotFound();
            }

            return Ok(autore);
        }

        // PUT: api/Autores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAutore(int id, Autore autore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autore.id_autor)
            {
                return BadRequest();
            }

            db.Entry(autore).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoreExists(id))
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

        // POST: api/Autores
        [ResponseType(typeof(Autore))]
        //public IHttpActionResult PostAutore(Autore autore)
        public string PostAutore(Autore autore)
        {
            if (!ModelState.IsValid)
            {
                // return BadRequest(ModelState);
                return "Autor \n " + autore.nome_autor + "\n Não foi adicionado!";
            }

            db.Autores.Add(autore);
            db.SaveChanges();
            return "Autor \n " + autore.nome_autor + "\n Adicionado com sucesso";
            //return CreatedAtRoute("DefaultApi", new { id = autore.id_autor }, autore);
        }

        // DELETE: api/Autores/5
        [ResponseType(typeof(Autore))]
        public IHttpActionResult DeleteAutore(int id)
        {
            Autore autore = db.Autores.Find(id);
            if (autore == null)
            {
                return NotFound();
            }

            db.Autores.Remove(autore);
            db.SaveChanges();

            return Ok(autore);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutoreExists(int id)
        {
            return db.Autores.Count(e => e.id_autor == id) > 0;
        }
    }
}

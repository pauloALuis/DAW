using projecto2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace projecto2.Controllers
{
    public class UtentesController : ApiController
    {
        private dbDsEntities db = new dbDsEntities();



        // GET: api/Utentes
        public IQueryable<Utente> GetUtentes()
        {
            return db.Utentes;
        }

        // GET: api/Emprestimos/5
        [System.Web.Http.Description.ResponseType(typeof(Utente))]
        public IHttpActionResult GetUtente(int id)
        {
            Utente utente = db.Utentes.Find(id);
            if (utente == null)
            {
                return NotFound();
            }

            return Ok(utente);
        }

        // PUT: api/Emprestimos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmprestimo(int id, Utente utente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != utente.id_utente)
            {
                return BadRequest();
            }

            db.Entry(utente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtenteExists(id))
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

        // POST: api/utente
        [ResponseType(typeof(string))]
        //public IHttpActionResult Postutente(utente utente)
        public string PostUtente(Utente utente)
        {
            if (!ModelState.IsValid)
            {
                // return BadRequest(ModelState);
                return "utente não adicionado";
            }
            //(string email, string passworduser, string nome_utente, string endereco_utente,
            //Nullable<System.DateTime> dta_nascim_utente, Nullable<int> num_tlm_utente)
           // db.Utentes(utente.email, utente.passworduser, utente.nome_utente, utente.endereco_utente,
             //   utente.dta_nascim_utente, utente.num_tlm_utente);
                
            db.Utentes.Add(utente);
            db.SaveChanges();
            return "Utente ID -" + utente.id_utente + "- adicionado com sucesso";

            //return CreatedAtRoute("DefaultApi", new { id = emprestimo.id_emprestimo }, emprestimo);
        }

        // DELETE: api/Emprestimos/5
        [ResponseType(typeof(Utente))]
        public IHttpActionResult DeleteUtente(int id)
        {
            Utente utente = db.Utentes.Find(id);
            if (utente == null)
            {
                return NotFound();
            }

            db.Utentes.Remove(utente);
            db.SaveChanges();

            return Ok(utente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UtenteExists(int id)
        {
            return db.Utentes.Count(e => e.id_utente == id) > 0;
        }
    }
}

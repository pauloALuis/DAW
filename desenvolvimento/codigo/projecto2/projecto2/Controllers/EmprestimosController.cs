using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;
using projecto2.Models;

namespace projecto2.Controllers
{
    public class EmprestimosController : ApiController
    {
        private dbDsEntities db = new dbDsEntities();

        // GET: api/Emprestimos
        public IQueryable<Emprestimo> GetEmprestimos()
        {
            return db.Emprestimos;
        }

   
        // GET: api/Emprestimos/5
        [ResponseType(typeof(Emprestimo))]
        public IHttpActionResult GetEmprestimo(int id)
        {

            var emprestimo = db.sp_GetEmprestimo(id).ToList();

           // Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return Ok(emprestimo);
        }







        // PUT: api/Emprestimos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmprestimo(int id, Emprestimo emprestimo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emprestimo.id_emprestimo)
            {
                return BadRequest();
            }

            db.Entry(emprestimo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmprestimoExists(id))
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

        // POST: api/Emprestimos
        [ResponseType(typeof(Emprestimo))]
        //public IHttpActionResult PostEmprestimo(Emprestimo emprestimo)
        public string PostEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // return BadRequest(ModelState);
                    return "Emprestimo não concedido";
                }
                db.Emprestimos.Add(emprestimo);
                db.SaveChanges();
                return "Emprestimo nº -" + emprestimo.id_emprestimo + "- Concedido com sucesso";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "Erro";      
        }

        // DELETE: api/Emprestimos/5
        [ResponseType(typeof(Emprestimo))]
        public IHttpActionResult DeleteEmprestimo(int id)
        {
            Emprestimo emprestimo = db.Emprestimos.Find(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            db.Emprestimos.Remove(emprestimo);
            db.SaveChanges();

            return Ok(emprestimo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmprestimoExists(int id)
        {
            return db.Emprestimos.Count(e => e.id_emprestimo == id) > 0;
        }
    }
}

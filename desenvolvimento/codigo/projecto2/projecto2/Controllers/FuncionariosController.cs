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
    public class FuncionariosController : ApiController
    {
        private dbDsEntities db = new dbDsEntities();
        // GET: api/Funcionarios
        public IQueryable<Funcionario> GetFuncionarios()
        {
            return db.Funcionarios;
        }

        // GET: api/Funcionarios/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult GetFuncionario(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        // PUT: api/Funcionarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncionario(int id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionario.id_funcionario)
            {
                return BadRequest();
            }

            db.Entry(funcionario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        [ResponseType(typeof(Funcionario))]
        //public IHttpActionResult PostFuncionario(Funcionario funcionario)
        public string PostFuncionario(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return "Funcionário" + funcionario.nome_funcionario + "Não foi adicionado!";

            }
            //string email, string passworduser, string nome_funcionario, string cc_funcionario,
            //Nullable<System.DateTime> data_nascimento_funcionario, Nullable<int> contato_funcionario
           // db.sp_CreateFuncionario_Result(funcionario.email, funcionario.passworduser, funcionario.nome_funcionario,
               // funcionario.cc_funcionario, funcionario.data_nascimento_funcionario, funcionario.num_tlm_utente);

            db.Funcionarios.Add(funcionario);
            db.SaveChanges();
            //  return CreatedAtRoute("DefaultApi", new { id = funcionario.id_funcionario }, funcionario);
            return "Funcionário ID - " + funcionario.id_funcionario +" - Adicionado com sucesso";

        }

        // DELETE: api/Funcionarios/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult DeleteFuncionario(int id)
        {
            Funcionario funcionario = db.Funcionarios.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            db.Funcionarios.Remove(funcionario);
            db.SaveChanges();

            return Ok(funcionario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncionarioExists(int id)
        {
            return db.Funcionarios.Count(e => e.id_funcionario == id) > 0;
        }
    }
}

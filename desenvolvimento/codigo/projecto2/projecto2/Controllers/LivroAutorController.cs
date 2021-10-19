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
    public class LivroAutorController : ApiController
    {
        private dbDsEntities db = new dbDsEntities();

        // GET: api/LivroAutor
        public IQueryable<Livro_Autor> GetLivro_Autor()
        {
            return db.Livro_Autor;
        }

        // GET: api/LivroAutor/5
        [ResponseType(typeof(LivroAutores))]
        public IHttpActionResult GetLivro_Autor(int id)
        {
        

            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return NotFound();
            }


            var d = db.Livro_Autor.Where(x => x.id_livro.Equals(id)).FirstOrDefault();
            Autore autor = db.Autores.Find(d.id_autor);
            LivroAutores v = new LivroAutores();


            v.id_livro = livro.id_livro;
            v.isbn_livro = livro.isbn_livro;
            v.qtd_livro = livro.qtd_livro;
            v.titulo_livro = livro.titulo_livro;
            v.obs_livro = livro.obs_livro;
            v.genero_livro = livro.genero_livro;
            v.flagAtivo = (bool)livro.flagAtivo;
            v.editorProdutora_livro = livro.editorProdutora_livro;
            v.numpaginas_livro = livro.numpaginas_livro;

            v.id_autor = autor.id_autor;
            v.nome_autor = autor.nome_autor;
            v.obs_autor = autor.obs_autor;
            v.email_autor = autor.email_autor;



            return Ok(v);
        }

        // PUT: api/LivroAutor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLivro_Autor(int id, Livro_Autor livro_Autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro_Autor.livroAutorID)
            {
                return BadRequest();
            }

            db.Entry(livro_Autor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Livro_AutorExists(id))
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

        // POST: api/LivroAutor
        [ResponseType(typeof(Livro_Autor))]
        public IHttpActionResult PostLivro_Autor(Livro_Autor livro_Autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Livro_Autor.Add(livro_Autor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = livro_Autor.livroAutorID }, livro_Autor);
        }

        // DELETE: api/LivroAutor/5
        [ResponseType(typeof(Livro_Autor))]
        public IHttpActionResult DeleteLivro_Autor(int id)
        {
            Livro_Autor livro_Autor = db.Livro_Autor.Find(id);
            if (livro_Autor == null)
            {
                return NotFound();
            }

            db.Livro_Autor.Remove(livro_Autor);
            db.SaveChanges();

            return Ok(livro_Autor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Livro_AutorExists(int id)
        {
            return db.Livro_Autor.Count(e => e.livroAutorID == id) > 0;
        }
    }
}
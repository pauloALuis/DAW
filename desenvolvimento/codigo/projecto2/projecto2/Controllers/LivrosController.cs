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
    public class LivrosController : ApiController
    {
        private dbDsEntities db = new dbDsEntities();
        // GET: api/Livro
        public IHttpActionResult GetLivro()
        {
            var result = db.sp_ListaLivroAutores().ToList();
            return Ok(result);
        }
  
        // GET: api/Livro/5
        [ResponseType(typeof(Livro))]
        public IHttpActionResult GetLivro(int id)
        {
            var result = db.Livros.Find(id);
            if (result == null)
            {
                return NotFound();
            }


            return Ok(result);
          
        }

  

        // PUT: api/Livro/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLivros(int id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.id_livro)
            {
                return BadRequest();
            }

            db.Entry(livro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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

        // POST: api/Livro
        [ResponseType(typeof(string))]
       public string PostLivro(sp_criarLivroAutor_Result livro)
        {
            if (!ModelState.IsValid)
            {
                return "utente não adicionado ";
            }

            var p = db.sp_criarLivroAutor(livro.id_Livro, livro.titulo_livro, livro.editorProdutora_livro, livro.genero_livro,
                           livro.qtd_livro, livro.obs_livro, livro.isbn_livro, livro.numpaginas_livro, livro.piccapa_livro,
                           livro.nome_autor, livro.email_autor,   livro.obs_autor,  livro.dataNascimento_autor, true           
                ).ToList();
            db.SaveChanges();
            return "Livro \n " + livro.titulo_livro + "\n Adicionado com sucesso";
        }

        // DELETE: api/Livro/5
        [ResponseType(typeof(Livro))]
        public IHttpActionResult DeleteLivro(int id)
        {


            Livro_Autor livroAutor = db.Livro_Autor.Where(c => c.id_livro.Equals(id)).FirstOrDefault();
            if (livroAutor == null)
            {
                return NotFound();
            }

            Livro livro = db.Livros.Find(livroAutor.id_livro);
            if (livro == null)
            {
                return NotFound();
            }


            Autore autore = db.Autores.Find(livroAutor.id_autor);
            if (autore == null)
            {
                return NotFound();
            }
            
            db.Livros.Remove(livro);
            db.Autores.Remove(autore);
            db.Livro_Autor.Remove(livroAutor);
            db.SaveChanges();

            return Ok(livro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LivroExists(int id)
        {
            return db.Livros.Count(e => e.id_livro == id) > 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projecto2.Models
{
    public class LivroAutores
    {
        public int id_livro { get; set; }
        public string titulo_livro { get; set; }
        public string editorProdutora_livro { get; set; }
        public string genero_livro { get; set; }
        public bool flagAtivo { get; set; }
        public Nullable<int> qtd_livro { get; set; }
        public string obs_livro { get; set; }
        public Nullable<long> isbn_livro { get; set; }
        public Nullable<int> numpaginas_livro { get; set; }
        public byte[] piccapa_livro { get; set; }
        public string nome_autor { get; set; }
        public int id_autor { get; set; }
        public string obs_autor { get; set; }
        public string email_autor { get; set; }
    }
}
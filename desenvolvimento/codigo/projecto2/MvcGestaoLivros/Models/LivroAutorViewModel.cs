using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class LivroAutorViewModel
    {
        [Required(ErrorMessage = " nome autor - Campo deve ser preenchido")]
        [DisplayName("Escritor")]

        public string nome_autor { get; set; }
        [DisplayName("Infor. do Escritor")]

        public string obs_autor { get; set; }
        [DisplayName("Email do Escritor")]

        public string email_autor { get; set; }
        [DisplayName("ID Escritor")]
        public int id_autor { get; set; }
       


        [DisplayName("ID")]

        public int id_livro { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "titulo livro - é obrigatório")]
        public string titulo_livro { get; set; }
        [DisplayName("Editor/Produtor")]

        public string editorProdutora_livro { get; set; }
        [DisplayName("Género")]

        public string genero_livro { get; set; }
        public Nullable<bool> flagAtivo { get; set; }
        [Required(ErrorMessage = "qtd livro - é obrigatório")]

        [DisplayName("Disponibilidade")]

        public Nullable<int> qtd_livro { get; set; }

        [DisplayName("Obs Livro")]

        public string obs_livro { get; set; }
        [DisplayName("ISBN")]

        public long isbn_livro { get; set; }
        [DisplayName("Nº Página")]

        public Nullable<int> numpaginas_livro { get; set; }
        public byte[] piccapa_livro { get; set; }
    }
}
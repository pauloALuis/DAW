using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class LivrosModel
    {
        [DisplayName("ID Livro")]

        public int id_Livro { get; set; }

        [DisplayName("ID Autor")]
        public int id_Autor { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public string titulo_livro { get; set; }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]

        public string nome_autor { get; set; }

        [DisplayName("Género")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public string genero_livro { get; set; }

        [DisplayName("Nº Página")]
        public Nullable<int> numpaginas_livro { get; set; }

        [DisplayName("Editor/Produtor")]
        public string editorProdutora_livro { get; set; }

        [DisplayName("Obs Livro")]
        public string obs_livro { get; set; }

        [DisplayName("ISBN")]
        public long isbn_livro { get; set; }

        [DisplayName("Disponibilidade")]
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        public Nullable<int> qtd_livro { get; set; }

        [DisplayName("Email Autor")]
        [Required(ErrorMessage = "Email Autor - é obrigatório")]

        public string email_autor { get; set; }

        [DisplayName("Obs Autor")]
        public string obs_autor { get; set; }

        [DisplayName("Data Nascimento")]
        public Nullable<System.DateTime> dataNascimento_autor { get; set; }

        [DisplayName("Ativo?")]
        public Nullable<bool> flagAtivo { get; set; }

        [DisplayName("Capa")]
        public byte[] piccapa_livro { get; set; }
    }
}
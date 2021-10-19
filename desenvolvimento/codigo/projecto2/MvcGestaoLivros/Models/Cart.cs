using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class Cart
    {

        [DisplayName("ID")]
        public int id_livro { get; set; }

        [DisplayName("Título")]

        //[Required(ErrorMessage = "titulo livro - é obrigatório")]
        public string titulo_livro { get; set; }
        [DisplayName("Qtd")]
        public string qtd { get; set; }

        [DisplayName("Obs")]
        public string obs_livro { get; set; }

        //  [DisplayName("Editor/Produtor")]
    }
}
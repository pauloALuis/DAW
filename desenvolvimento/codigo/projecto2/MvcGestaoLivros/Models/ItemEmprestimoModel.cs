using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class ItemEmprestimoModel
    {
        [Display(Name = "ID")]

        public int id_Details_Empres { get; set; }
        [Required(ErrorMessage = "ID emprestimo -  Campo obrigatório")]
        [Display(Name = "ID Emprestimos")]

        public int id_emprestimo { get; set; }
        [Required(ErrorMessage = "ID LIVRO - Campo obrigatório")]
        [Display(Name = "ID Livro")]
        public int id_livro { get; set; }

    }
}
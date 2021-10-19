using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class Funcionarios
    {   [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome funcionario - é obrigatório")]
        public string nome_funcionario { get; set; }
        [Display(Name = "Nº Documento")]
        public string cc_funcionario { get; set; } 

        [Display(Name= "Data Nascimento")]
        [Required(ErrorMessage = "data nascimento funcionario - é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime data_nascimento_funcionario { get; set; }
        [Display(Name = "Email")]
        public string email_funcionario { get; set; }
        [Display(Name = "Telemóvel")]
        public string contato_funcionario { get; set; }
        [Display(Name = "ID")]
        public int id_funcionario { get; set; }
        [Display(Name = "ID Login")]
        [Required(ErrorMessage = "id login - é obrigatório")]
        public int id_login { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class FuncionariosModel
    {
       



        [Required(ErrorMessage = "Nome funcionario - é obrigatório")]
        [Display(Name = "Nome Completo")]
        public string nome_funcionario { get; set; }
        [Display(Name = "Nº Documento")]
        public string cc_funcionario { get; set; }
        [Required(ErrorMessage = "data nascimento funcionario - é obrigatório")]
        [DisplayName("Data Nascimento")]

        public System.DateTime data_nascimento_funcionario { get; set; }


        [Display(Name = "Email")]
        public string email_funcionario { get; set; }

        [Display(Name = "Telemóvel")]
        public string contato_funcionario { get; set; }

        [Display(Name = "ID")]
        public int id_funcionario { get; set; }
        [Required(ErrorMessage = "id login - é obrigatório")]
        [Display(Name = "ID Login")]
        public int id_login { get; set; }







    }
}
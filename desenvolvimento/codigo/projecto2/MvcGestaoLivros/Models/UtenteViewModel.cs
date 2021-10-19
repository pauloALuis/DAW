using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class UtenteViewModel
    {
        [Display(Name = "ID")]
        public int id_utente { get; set; }
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Nome Completo")]
        public string nome_utente { get; set; }
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        [Display(Name = "Endereço")]
        public string endereco_utente { get; set; }
        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Apenas data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> dta_nascim_utente { get; set; }
        [Required(ErrorMessage = "Campo deve ser preenchido")]
        [Display(Name = "Telemóvel")]
        public Nullable<int> num_tlm_utente { get; set; }
        [Required(ErrorMessage = "id login - é obrigatório")]
        [Display(Name = "ID")]
        public int id_login { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "email é obrigatório")]
        public string email { get; set; }
        [DisplayName("Nome Utilizador")]
        [Required(ErrorMessage = "Nome de utilizador é obrigatório")]
        public string username { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Palavra-passe")]
        [Required(ErrorMessage = "Palavra-passe é obrigatório")]
        public string password { get; set; }
        [DisplayName("Tipo de utilizador")]

        public Nullable<bool> flagAtiva { get; set; }

        [DisplayName("Tipo de Utilizador")]
        [Required(ErrorMessage = "Privilégio é obrigatório")]

        public bool privilegio { get; set; }
    }
}
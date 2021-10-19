using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class UtentesModel
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

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<Emprestimo> Emprestimos { get; set; } 
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<login> logins { get; set; }
    }
}
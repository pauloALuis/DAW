using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class EmprestimoModel
    {
        [Display(Name = "ID")]
        public int id_emprestimo { get; set; }
        [Required(ErrorMessage = "id utente - Campo obrigatório ")]
        [Display(Name = "Nº utente")]

        public int id_utente { get; set; }
        [Required(ErrorMessage = "data requisicao emprestimo - Campo obrigatório ")]
        [Display(Name = "Data Requisição")]

        public DateTime data_requisicao_emprestimo { get; set; }
        [Required(ErrorMessage = "data devolucao emprestimo - Campo obrigatório ")]
        [Display(Name = "Data P/ Devolução")]
        public DateTime data_devolucao_emprestimo { get; set; }
        [Display(Name = "Data limite de Entrega")]

        public Nullable<DateTime> data_entrega_emprestimo { get; set; }
        public string obs_emprestimo { get; set; }
        [Display(Name = "Situação")]
        [Required(ErrorMessage = "status emprestimo - Campo obrigatório ")]
        public string status_emprestimo { get; set; }
        [Display(Name = "Valor Multa")]
        public string multa_valor_emprestimo { get; set; }
        [Display(Name = "Disponibilidade")]

        public bool flagAtiva { get; set; }

    


    }
}
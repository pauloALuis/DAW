using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGestaoLivros.Models
{
    public class EmprestimoViewModel
    {
        [Display(Name = "ID")]
        public int id_livro { get; set; }
        [Required(ErrorMessage = "Campo obrigatório ")]
        [Display(Name = "Título")]
        public string titulo_livro { get; set; }
        [Required(ErrorMessage = "Campo obrigatório ")]
        [Display(Name = "Editor/Produtor")]
        public string editorProdutora_livro { get; set; }
        [Required(ErrorMessage = "Campo obrigatório ")]
        [Display(Name = "Classificação Temática")]
        public string genero_livro { get; set; }
        public Nullable<bool> flagAtivo { get; set; }
        [Required(ErrorMessage = "Campo obrigatório ")]
        [Display(Name = "Quantidade Disponível")]
        public Nullable<int> qtd_livro { get; set; }
        [Display(Name = "Observações sobre o livro")]
        public string obs_livro { get; set; }

        [Display(Name = "ISBN")]
        public long isbn_livro { get; set; }
        [Display(Name = "Nº Pág")]
        public Nullable<int> numpaginas_livro { get; set; }
        [Display(Name = "Capa")]
        public byte[] piccapa_livro { get; set; }
        [Required(ErrorMessage = "Campo obrigatório ")]
        [Display(Name = "Autor")]
        public string nome_autor { get; set; }
        [Display(Name = "ID Autor")]

        public int id_autor { get; set; }
        public int id_emprestimo { get; set; }
        [Required(ErrorMessage = "Campo obrigatório ")]
        [Display(Name = "ID Utente")]
        public int id_utente { get; set; }

        [Required(ErrorMessage = "Data Requisição  - Campo obrigatório ")]

        [Display(Name = "Data Requisição ")]
        public Nullable<System.DateTime> data_requisicao_emprestimo { get; set; }
        [Required(ErrorMessage = "Data Devolução  - Campo obrigatório ")]
        [Display(Name = "Data Devolução")]
        public Nullable<System.DateTime> data_devolucao_emprestimo { get; set; }
        [Display(Name = "Data Entrega")]
        public Nullable<System.DateTime> data_entrega_emprestimo { get; set; }
        [Display(Name = "Observações")]
        public string obs_emprestimo { get; set; }
        [Display(Name = "Status")]
        public string status_emprestimo { get; set; }
        [Display(Name = "Multa")]
        public string multa_valor_emprestimo { get; set; }
        public Nullable<bool> flagAtiva { get; set; }
        [Display(Name = "Data Nascimento Utente")]
        public Nullable<System.DateTime> dta_nascim_utente { get; set; }
        [Display(Name = "Telemovel")]
        public Nullable<int> num_tlm_utente { get; set; }
        [Display(Name = "Endereço")]

        public string endereco_utente { get; set; }
        [Display(Name = "Utente")]
        public string nome_utente { get; set; }
    }
}
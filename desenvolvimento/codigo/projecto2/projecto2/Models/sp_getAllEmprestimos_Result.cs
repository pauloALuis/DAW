//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projecto2.Models
{
    using System;
    
    public partial class sp_getAllEmprestimos_Result
    {
        public int id_livro { get; set; }
        public string titulo_livro { get; set; }
        public string editorProdutora_livro { get; set; }
        public string genero_livro { get; set; }
        public Nullable<bool> flagAtivo { get; set; }
        public Nullable<int> qtd_livro { get; set; }
        public string obs_livro { get; set; }
        public long isbn_livro { get; set; }
        public Nullable<int> numpaginas_livro { get; set; }
        public byte[] piccapa_livro { get; set; }
        public string nome_autor { get; set; }
        public int id_autor { get; set; }
        public int id_emprestimo { get; set; }
        public int id_utente { get; set; }
        public Nullable<System.DateTime> data_requisicao_emprestimo { get; set; }
        public Nullable<System.DateTime> data_devolucao_emprestimo { get; set; }
        public Nullable<System.DateTime> data_entrega_emprestimo { get; set; }
        public string obs_emprestimo { get; set; }
        public string status_emprestimo { get; set; }
        public string multa_valor_emprestimo { get; set; }
        public Nullable<bool> flagAtiva { get; set; }
        public Nullable<System.DateTime> dta_nascim_utente { get; set; }
        public Nullable<int> num_tlm_utente { get; set; }
        public string endereco_utente { get; set; }
        public string nome_utente { get; set; }
    }
}

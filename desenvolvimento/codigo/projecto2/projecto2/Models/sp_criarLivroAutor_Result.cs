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
    
    public partial class sp_criarLivroAutor_Result
    {
        public int id_Livro { get; set; }
        public int id_Autor { get; set; }
        public string titulo_livro { get; set; }
        public string nome_autor { get; set; }
        public string genero_livro { get; set; }
        public Nullable<int> numpaginas_livro { get; set; }
        public string editorProdutora_livro { get; set; }
        public string obs_livro { get; set; }
        public long isbn_livro { get; set; }
        public Nullable<int> qtd_livro { get; set; }
        public string email_autor { get; set; }
        public string obs_autor { get; set; }
        public Nullable<System.DateTime> dataNascimento_autor { get; set; }
        public Nullable<bool> flagAtivo { get; set; }
        public byte[] piccapa_livro { get; set; }
    }
}

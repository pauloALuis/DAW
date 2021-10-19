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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Funcionario
    {
        [Required(ErrorMessage = "Nome Funcionario - Campo deve ser preenchido")]
        public string nome_funcionario { get; set; }

        public string cc_funcionario { get; set; }
        [Required(ErrorMessage = "Data Nascimento - Campo deve ser preenchido")]
        public Nullable<System.DateTime> data_nascimento_funcionario { get; set; }
        public string email_funcionario { get; set; }
        public string contato_funcionario { get; set; }
        public int id_funcionario { get; set; }
        [Required(ErrorMessage = "ID Login - Campo deve ser preenchido")]
        public int id_login { get; set; }
    
        public virtual login login { get; set; }
    }
}
